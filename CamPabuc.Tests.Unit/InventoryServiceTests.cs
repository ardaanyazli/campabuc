using Moq;
using Xunit;
using CamPabuc.Application.Services;
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;

namespace CamPabuc.Tests.Unit;

public class InventoryServiceTests
{
    private readonly Mock<IPurchaseOrderRepository> _poRepoMock = new();
    private readonly Mock<IShoeVariantRepository> _variantRepoMock = new();
    private readonly Mock<ISaleRepository> _saleRepoMock = new();
    private readonly Mock<IStockAdjustmentRepository> _adjustmentRepoMock = new();
    private readonly Mock<IUnitOfWork> _uowMock = new();
    private readonly InventoryService _service;

    public InventoryServiceTests()
    {
        _service = new InventoryService(
            _poRepoMock.Object,
            _variantRepoMock.Object,
            _saleRepoMock.Object,
            _adjustmentRepoMock.Object,
            _uowMock.Object
        );
    }

    [Fact]
    public async Task ProcessPurchaseOrder_ShouldIncreaseStock()
    {
        // Arrange
        var ct = CancellationToken.None;
        var variant = new ShoeVariant { Id = 1, StockQuantity = 10 };
        var po = new PurchaseOrder 
        { 
            Id = 1, 
            Status = PurchaseOrderStatus.Pending, 
            Items = new List<POItem> { new POItem { ShoeVariantId = 1, QuantityReceived = 5 } } 
        };

        _poRepoMock.Setup(r => r.GetPurchaseOrderAsync(1, ct)).ReturnsAsync(po);
        _variantRepoMock.Setup(r => r.GetVariantAsync(1, ct)).ReturnsAsync(variant);

        // Act
        await _service.ProcessPurchaseOrder(1, ct);

        // Assert
        Assert.Equal(15, variant.StockQuantity);
        Assert.Equal(PurchaseOrderStatus.Received, po.Status);
        _uowMock.Verify(u => u.SaveChangesAsync(ct), Times.Once);
    }

    [Fact]
    public async Task ProcessSale_ShouldDecreaseStock()
    {
        // Arrange
        var ct = CancellationToken.None;
        var variant = new ShoeVariant { Id = 1, StockQuantity = 10 };
        var sale = new Sale 
        { 
            Id = 1, 
            Items = new List<SaleItem> { new SaleItem { ShoeVariantId = 1, Quantity = 3 } } 
        };

        _saleRepoMock.Setup(r => r.GetSaleAsync(1, ct)).ReturnsAsync(sale);
        _variantRepoMock.Setup(r => r.GetVariantAsync(1, ct)).ReturnsAsync(variant);

        // Act
        await _service.ProcessSale(1, ct);

        // Assert
        Assert.Equal(7, variant.StockQuantity);
        _uowMock.Verify(u => u.SaveChangesAsync(ct), Times.Once);
    }

    [Fact]
    public async Task ProcessSale_InsufficientStock_ShouldThrowException()
    {
        // Arrange
        var ct = CancellationToken.None;
        var variant = new ShoeVariant { Id = 1, StockQuantity = 2 };
        var sale = new Sale 
        { 
            Id = 1, 
            Items = new List<SaleItem> { new SaleItem { ShoeVariantId = 1, Quantity = 5 } } 
        };

        _saleRepoMock.Setup(r => r.GetSaleAsync(1, ct)).ReturnsAsync(sale);
        _variantRepoMock.Setup(r => r.GetVariantAsync(1, ct)).ReturnsAsync(variant);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _service.ProcessSale(1, ct));
    }
}
