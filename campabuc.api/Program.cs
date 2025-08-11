
using CamPabuc.API.Middleware;
using CamPabuc.Application.DTO;
using CamPabuc.Application.Interface;
using CamPabuc.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IShoeRepository, ShoeRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddScoped<IContactsUnitOfWork, ContactsUnitOfWork>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RequestCancellationMiddleware>();

app.UseHttpsRedirection();


app.MapGet("/shoes", async (IShoeRepository shoeRepository, CancellationToken cancellationToken) =>
{
    var shoes = await shoeRepository.GetAll(cancellationToken);
    var shoeList = shoes.Select(s => new ShoeListDto(s.Id, s.Barcode, s.Price, s.Stock, s.Color, s.Gender.Select(g => g.Name).ToList())).ToList();

    return Results.Ok(shoeList);
}).WithName("GetAllShoes");


app.Run();

