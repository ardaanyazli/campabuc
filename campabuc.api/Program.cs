using CamPabuc.API.Middleware;
using CamPabuc.Application.DTO;
using CamPabuc.Application.Interface;
using CamPabuc.Domain.Entity;
using CamPabuc.Domain.Enums;
using CamPabuc.Infrastructure.Persistence;
using CamPabuc.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddOpenApi();

// Add Entity Framework
builder.Services.AddDbContext<CamPabucContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CamPabucConnection")));

// Register repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

// SHOE ENDPOINTS
app.MapGet("/api/shoes", async (IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    var shoes = await unitOfWork.ShoeRepository.GetShoesAsync(cancellationToken);

})
.WithName("GetAllShoes")
.WithOpenApi();

app.MapGet("/api/shoes/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var shoe = await unitOfWork.ShoeRepository.GetShoeAsync(id, cancellationToken).ToDetailDto();


        return Results.Ok(shoe);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Shoe with ID {id} not found");
    }
})
.WithName("GetShoeById")
.WithOpenApi();

app.MapPost("/api/shoes", async (Shoe shoe, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    shoe.Id = Guid.NewGuid();
    shoe.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    shoe.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    shoe.IsActive = true;
    await unitOfWork.ShoeRepository.CreateShoeAsync(shoe, cancellationToken);

    return Results.Created($"/api/shoes/{shoe.Id}", shoe);
})
.WithName("CreateShoe")
.WithOpenApi();

app.MapPut("/api/shoes/{id:guid}", async (Guid id, Shoe shoe, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var existingShoe = await unitOfWork.ShoeRepository.GetShoeAsync(id, cancellationToken);
        shoe.Id = id;
        shoe.CreatedAt = existingShoe.CreatedAt;
        shoe.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        unitOfWork.ShoeRepository.UpdateShoe(shoe);

        return Results.Ok(shoe);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Shoe with ID {id} not found");
    }
})
.WithName("UpdateShoe")
.WithOpenApi();

app.MapDelete("/api/shoes/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        await unitOfWork.ShoeRepository.DeleteShoeAsync(id, cancellationToken);
        return Results.NoContent();
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Shoe with ID {id} not found");
    }
})
.WithName("DeleteShoe")
.WithOpenApi();

// MANUFACTURER ENDPOINTS
app.MapGet("/api/manufacturers", async (IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    var manufacturers = await unitOfWork.ManufacturerRepository.GetAll(cancellationToken);
    return Results.Ok(manufacturers);
})
.WithName("GetAllManufacturers")
.WithOpenApi();

app.MapGet("/api/manufacturers/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var manufacturer = await unitOfWork.ManufacturerRepository.GetById(id, cancellationToken);
        return Results.Ok(manufacturer);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Manufacturer with ID {id} not found");
    }
})
.WithName("GetManufacturerById")
.WithOpenApi();

app.MapPost("/api/manufacturers", async (Manufacturer manufacturer, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    manufacturer.Id = Guid.NewGuid();
    manufacturer.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    manufacturer.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    manufacturer.IsActive = true;
    await unitOfWork.ManufacturerRepository.CreateManufacturer(manufacturer, cancellationToken);
    return Results.Created($"/api/manufacturers/{manufacturer.Id}", manufacturer);
})
.WithName("CreateManufacturer")
.WithOpenApi();

app.MapPut("/api/manufacturers/{id:guid}", async (Guid id, Manufacturer manufacturer, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var existingManufacturer = await unitOfWork.ManufacturerRepository.GetById(id, cancellationToken);
        manufacturer.Id = id;
        manufacturer.CreatedAt = existingManufacturer.CreatedAt;
        manufacturer.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        await unitOfWork.ManufacturerRepository.UpdateManufacturer(manufacturer, cancellationToken);
        return Results.Ok(manufacturer);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Manufacturer with ID {id} not found");
    }
})
.WithName("UpdateManufacturer")
.WithOpenApi();

app.MapDelete("/api/manufacturers/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        await unitOfWork.ManufacturerRepository.DeleteManufacturer(id, cancellationToken);
        return Results.NoContent();
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"Manufacturer with ID {id} not found");
    }
})
.WithName("DeleteManufacturer")
.WithOpenApi();

// CONTACT ENDPOINTS
app.MapGet("/api/contacts", async (IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    var contacts = await unitOfWork.ContactRepository.GetContactsAsync(cancellationToken);
    return Results.Ok(contacts);
})
.WithName("GetAllContacts")
.WithOpenApi();

app.MapGet("/api/contacts/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var contact = await unitOfWork.ContactRepository.GetContactByIdAsync(id, cancellationToken);
        return Results.Ok(contact);
    }
    catch (NullReferenceException)
    {
        return Results.NotFound($"Contact with ID {id} not found");
    }
})
.WithName("GetContactById")
.WithOpenApi();

app.MapPost("/api/contacts", async (Contact contact, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    contact.Id = Guid.NewGuid();
    contact.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    contact.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    contact.IsActive = true;
    await unitOfWork.ContactRepository.CreateContactAsync(contact, cancellationToken);
    await unitOfWork.SaveChangesAsync(cancellationToken);
    return Results.Created($"/api/contacts/{contact.Id}", contact);
})
.WithName("CreateContact")
.WithOpenApi();

app.MapPut("/api/contacts/{id:guid}", async (Guid id, Contact contact, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var existingContact = await unitOfWork.ContactRepository.GetContactByIdAsync(id, cancellationToken);
        contact.Id = id;
        contact.CreatedAt = existingContact.CreatedAt;
        contact.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        unitOfWork.ContactRepository.UpdateContact(contact);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Ok(contact);
    }
    catch (NullReferenceException)
    {
        return Results.NotFound($"Contact with ID {id} not found");
    }
})
.WithName("UpdateContact")
.WithOpenApi();

app.MapDelete("/api/contacts/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        await unitOfWork.ContactRepository.DeleteContactAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
    catch (NullReferenceException)
    {
        return Results.NotFound($"Contact with ID {id} not found");
    }
})
.WithName("DeleteContact")
.WithOpenApi();

// CONTACT INFO ENDPOINTS
app.MapGet("/api/contactinfos", async (IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    var contactInfos = await unitOfWork.ContactInfoRepository.GetContactInfosAsync(cancellationToken);

    return Results.Ok(contactInfos);
})
.WithName("GetAllContactInfos")
.WithOpenApi();

app.MapGet("/api/contactinfos/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var contactInfo = await unitOfWork.ContactInfoRepository.GetContactInfoAsync(id, cancellationToken);

        return Results.Ok(contactInfo);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"ContactInfo with ID {id} not found");
    }
})
.WithName("GetContactInfoById")
.WithOpenApi();

app.MapGet("/api/contacts/{contactId:guid}/contactinfos", async (Guid contactId, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var contactInfos = await unitOfWork.ContactInfoRepository.GetContactInfoByContactIdAsync(contactId, cancellationToken);

        return Results.Ok(contactInfos);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"No ContactInfos found for Contact ID {contactId}");
    }
})
.WithName("GetContactInfosByContactId")
.WithOpenApi();

app.MapPost("/api/contactinfos", async (ContactInfo contactInfo, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    contactInfo.Id = Guid.NewGuid();
    contactInfo.CreatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    contactInfo.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
    contactInfo.IsActive = true;

    await unitOfWork.ContactInfoRepository.AddContactInfoAsync(contactInfo, cancellationToken);
    await unitOfWork.SaveChangesAsync(cancellationToken);

    return Results.Created($"/api/contactinfos/{contactInfo.Id}", contactInfo);
})
.WithName("CreateContactInfo")
.WithOpenApi();

app.MapPut("/api/contactinfos/{id:guid}", async (Guid id, ContactInfo contactInfo, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        var existingContactInfo = await unitOfWork.ContactInfoRepository.GetContactInfoAsync(id, cancellationToken);
        contactInfo.Id = id;
        contactInfo.CreatedAt = existingContactInfo.CreatedAt;
        contactInfo.UpdatedAt = DateOnly.FromDateTime(DateTime.UtcNow);
        unitOfWork.ContactInfoRepository.UpdateContactInfo(contactInfo);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Results.Ok(contactInfo);
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"ContactInfo with ID {id} not found");
    }
})
.WithName("UpdateContactInfo")
.WithOpenApi();

app.MapDelete("/api/contactinfos/{id:guid}", async (Guid id, IUnitOfWork unitOfWork, CancellationToken cancellationToken) =>
{
    try
    {
        await unitOfWork.ContactInfoRepository.DeleteContactInfoAsync(id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Results.NoContent();
    }
    catch (KeyNotFoundException)
    {
        return Results.NotFound($"ContactInfo with ID {id} not found");
    }
})
.WithName("DeleteContactInfo")
.WithOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "ContactBook Contacts API V1");
    });

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<CamPabucContext>();
        db.Database.Migrate(); // Ensures DB and schema exist
    }
}
app.Run();

// Helper method to convert ShoeGender enum to list of strings
static List<string> GetGenderNames(ShoeGender gender)
{
    var genders = new List<string>();
    if (gender.HasFlag(ShoeGender.Male))
        genders.Add("Male");
    if (gender.HasFlag(ShoeGender.Female))
        genders.Add("Female");
    if (gender.HasFlag(ShoeGender.Child))
        genders.Add("Child");
    if (gender.HasFlag(ShoeGender.Baby))
        genders.Add("Baby");
    return genders;
}
