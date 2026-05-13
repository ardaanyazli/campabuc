using CamPabuc.Api.Middleware;
using CamPabuc.Application.DTO;
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;
using CamPabuc.Infrastructure.Persistence;
using CamPabuc.Infrastructure.Repository;
using CamPabuc.Application.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add Entity Framework
builder.Services.AddDbContext<CamPabucContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CamPabucConnection") ?? "Data Source=campabuc.db"));

// Register repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IShoeModelRepository, ShoeModelRepository>();
builder.Services.AddScoped<IShoeVariantRepository, ShoeVariantRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IStockAdjustmentRepository, StockAdjustmentRepository>();

// Register Services
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();
builder.Services.AddScoped<IReportingService, ReportingService>();
builder.Services.AddScoped<IDataManagementService, DataManagementService>();

// Add CORS if needed
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestCancellationMiddleware>();
app.UseHttpsRedirection();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "CamPabuc Shoes API V2");
    });

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<CamPabucContext>();
        db.Database.Migrate(); 
    }
}
app.Run();

// Make Program class public so it can be accessed by the integration test project
public partial class Program { }
