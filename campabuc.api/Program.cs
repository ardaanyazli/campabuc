using campabuc.data.interfaces;
using campabuc.data;
using campabuc.api.Models;
using MessagePack;
using MessagePack.AspNetCoreMvcFormatter;
using Microsoft.AspNetCore.Mvc.Formatters;
using campabuc.api.Models.DTO;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

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
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
    {
        // Add binary formats
        "application/x-msgpack",
        "application/json"
    });
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest; // or Optimal
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseResponseCompression();
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

app.MapPost("shoes/sync", async (HttpRequest request) =>
{
    if (request.Headers.ContentEncoding == "br")
    {
        using var brotli = new BrotliStream(request.Body, CompressionMode.Decompress);
        using var memory = new MemoryStream();
        await brotli.CopyToAsync(memory);
        memory.Position = 0;

        var manufacturers = MessagePackSerializer.Deserialize<List<ManufacturerDto>>(memory.ToArray());
        // handle data...
        return Results.Ok();
    }

    return Results.BadRequest("Expected Brotli compression");
    if (!request.ContentType?.Contains("application/x-msgpack") ?? true)
        return Results.BadRequest("Unsupported content type");

    // Deserialize MessagePack from body
    var buffer = new MemoryStream();
    await request.Body.CopyToAsync(buffer);
    buffer.Position = 0;

    var shoes = MessagePackSerializer.Deserialize<List<ShoeDto>>(buffer.ToArray());

    // TODO: Save to SQLite or process data here

    return Results.Ok(new { Count = shoes.Count });
}).WithName("Sync Shoes");

app.MapPost("manufacturers/sync", async (HttpRequest request) =>
{
    if (!request.ContentType?.Contains("application/x-msgpack") ?? true)
        return Results.BadRequest("Unsupported content type");

    // Deserialize MessagePack from body
    var buffer = new MemoryStream();
    await request.Body.CopyToAsync(buffer);
    buffer.Position = 0;

    var manufacturers = MessagePackSerializer.Deserialize<List<ManufacturerDto>>(buffer.ToArray());

    // TODO: Save to SQLite or process data here

    return Results.Ok(new { Count = manufacturers.Count });
}).WithName("Sync Colors");

app.MapPost("colors/sync", async (HttpRequest request) =>
{
    if (!request.ContentType?.Contains("application/x-msgpack") ?? true)
        return Results.BadRequest("Unsupported content type");

    // Deserialize MessagePack from body
    var buffer = new MemoryStream();
    await request.Body.CopyToAsync(buffer);
    buffer.Position = 0;

    var colors = MessagePackSerializer.Deserialize<List<ColorDto>>(buffer.ToArray());

    // TODO: Save to SQLite or process data here

    return Results.Ok(new { Count = colors.Count });
}).WithName("Sync Colors");

app.MapPost("orders/sync", async (HttpRequest request) =>
{
    if (!request.ContentType?.Contains("application/x-msgpack") ?? true)
        return Results.BadRequest("Unsupported content type");

    // Deserialize MessagePack from body
    var buffer = new MemoryStream();
    await request.Body.CopyToAsync(buffer);
    buffer.Position = 0;

    var orders = MessagePackSerializer.Deserialize<List<OrderDto>>(buffer.ToArray());

    // TODO: Save to SQLite or process data here

    return Results.Ok(new { Count = orders.Count });
}).WithName("Sync Orders");

app.MapPost("order-items/sync", async (HttpRequest request) =>
{
    if (!request.ContentType?.Contains("application/x-msgpack") ?? true)
        return Results.BadRequest("Unsupported content type");

    // Deserialize MessagePack from body
    var buffer = new MemoryStream();
    await request.Body.CopyToAsync(buffer);
    buffer.Position = 0;

    var orderItems = MessagePackSerializer.Deserialize<List<OrderItemDto>>(buffer.ToArray());

    // TODO: Save to SQLite or process data here

    return Results.Ok(new { Count = orderItems.Count });
}).WithName("Sync Order Items");

app.MapPost("materials/sync", async (HttpRequest request) =>
{
    if (!request.ContentType?.Contains("application/x-msgpack") ?? true)
        return Results.BadRequest("Unsupported content type");

    // Deserialize MessagePack from body
    var buffer = new MemoryStream();
    await request.Body.CopyToAsync(buffer);
    buffer.Position = 0;

    var materials = MessagePackSerializer.Deserialize<List<MaterialDto>>(buffer.ToArray());

    // TODO: Save to SQLite or process data here

    return Results.Ok(new { Count = materials.Count });
}).WithName("Sync Materials");
app.Run();

