var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/shoes", async () => { }).WithName("Get shoes list");
app.MapGet("/categories", async () => { }).WithName("Get categories list");
app.MapGet("/sizes", async () => { }).WithName("Get shoe sizes list");
app.MapGet("/colors", async () => { }).WithName("Get Shoe colors list");
app.MapGet("/manufacturers", async () => { }).WithName("Get manufacturers list");
app.MapGet("/orders", async () => { }).WithName("Get orders list");

app.Run();

