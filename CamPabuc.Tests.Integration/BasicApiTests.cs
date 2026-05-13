using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using CamPabuc.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CamPabuc.Tests.Integration;

public class BasicApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public BasicApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Remove the actual SQLite provider to avoid conflicts
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CamPabucContext>));
                if (descriptor != null) services.Remove(descriptor);

                // Use a temporary SQLite database for integration tests
                services.AddDbContext<CamPabucContext>(options =>
                {
                    options.UseSqlite("Data Source=TestDb.db");
                });
            });
        });
    }

    [Fact]
    public async Task GetShoeModels_ReturnsSuccess()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/ShoeModels");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
