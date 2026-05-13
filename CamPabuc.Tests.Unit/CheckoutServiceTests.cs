using Moq;
using Xunit;
using CamPabuc.Application.Services;
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;

namespace CamPabuc.Tests.Unit;

public class CheckoutServiceTests
{
    private readonly Mock<ISaleRepository> _saleRepoMock = new();
    private readonly Mock<IUnitOfWork> _uowMock = new();
    private readonly CheckoutService _service;

    public CheckoutServiceTests()
    {
        _service = new CheckoutService(_saleRepoMock.Object, _uowMock.Object);
    }

    [Fact]
    public void CalculateSubtotal_ShouldReturnCorrectSum()
    {
        // Arrange
        var items = new List<SaleItem>
        {
            new SaleItem { PriceAtSale = 100, Quantity = 2 }, // 200
            new SaleItem { PriceAtSale = 50, Quantity = 1 },  // 50
        };

        // Act
        var result = _service.CalculateSubtotal(items);

        // Assert
        Assert.Equal(250, result);
    }

    [Fact]
    public void ApplyDiscount_ShouldReturnCorrectDiscountedPrice()
    {
        // Arrange
        decimal subtotal = 1000;
        decimal percent = 10; // 10% of 1000 = 100
        decimal fixedAmount = 50;

        // Act
        var result = _service.ApplyDiscount(subtotal, percent, fixedAmount);

        // Assert
        // 1000 * (1 - 0.1) = 900. 900 - 50 = 850.
        Assert.Equal(850, result);
    }

    [Fact]
    public void CalculateTotal_ShouldApplyTax()
    {
        // Arrange
        decimal subtotal = 1000;
        decimal taxRate = 0.20m; // 20%
        decimal discount = 100;

        // Act
        var result = _service.CalculateTotal(subtotal, taxRate, discount);

        // Assert
        // (1000 - 100) * 1.2 = 900 * 1.2 = 1080
        Assert.Equal(1080, result);
    }
}
