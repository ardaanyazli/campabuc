using campabuc.data.interfaces;
using campabuc.data;
using campabuc.api.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddTransient<IManufacturerRepository, ManufacturerRepository>(_ => { return new ManufacturerRepository(builder.Configuration.GetConnectionString("db")); });
builder.Services.AddTransient<IShoeColorRepository, ShoeColorRepository>(_ =>
{
    return new ShoeColorRepository(builder.Configuration.GetConnectionString("db"));
});
builder.Services.AddTransient<IShoeRepository, ShoeRepository>(_ => { return new ShoeRepository(builder.Configuration.GetConnectionString("db")); });
builder.Services.AddTransient<IShoeMaterialRepository, ShoeMaterialRepository>(_ => { return new ShoeMaterialRepository(builder.Configuration.GetConnectionString("db")); });
builder.Services.AddTransient<IShoeSizeRepository, ShoeSizeRepository>(_ => { return new ShoeSizeRepository(builder.Configuration.GetConnectionString("db")); });
builder.Services.AddTransient<IOrderRepository, OrderRepository>(_ => { return new OrderRepository(builder.Configuration.GetConnectionString("db")); });
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>(_ => { return new OrderItemRepository(builder.Configuration.GetConnectionString("db")); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/shoes", async (IShoeRepository repository) =>
{
    var shoeList = await repository.GetAll();
    return TypedResults.Ok(shoeList);
}).WithName("Get shoes list");
app.MapGet("/categories", () => { return TypedResults.Ok(Enum.GetNames(typeof(ShoeCategory))); }).WithName("Get categories list");
app.MapGet("/sizes", async (IShoeSizeRepository repository) =>
{
    var shoeSizeList = await repository.GetAll();
    return TypedResults.Ok(shoeSizeList);
}).WithName("Get shoe sizes list");
app.MapGet("/colors", async (IShoeColorRepository repository) =>
{
    var list = await repository.GetAll();
    return TypedResults.Ok(list);
}).WithName("Get Shoe colors list");
app.MapGet("/manufacturers", async (IManufacturerRepository repository) =>
{
    var list = await repository.GetAll();
    return TypedResults.Ok(list);
}).WithName("Get manufacturers list");
app.MapGet("/orders", async (IOrderRepository repository) =>
{
    var list = repository.GetAll();
    return TypedResults.Ok(list);
}).WithName("Get orders list");

app.Run();

