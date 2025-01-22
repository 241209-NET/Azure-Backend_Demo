using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PetTracker.API.Data;
using PetTracker.API.Model;
using PetTracker.API.Repository;
using PetTracker.API.Service;

var builder = WebApplication.CreateBuilder(args);

//Add dbcontext and connect it to connection string
builder.Services.AddDbContext<PetContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetsDB_Azure")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "Bearer",
                In = ParameterLocation.Header,
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

});

//Dependency Inject the proper services
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();

//Dependency Inject the proper repositories
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

//Add automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Add our controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddAuthorization()
    .AddOptions<BearerTokenOptions>(IdentityConstants.BearerScheme).Configure(options =>
    {
        //options.BearerTokenExpiration = TimeSpan.FromSeconds(30);
        //options.RefreshTokenExpiration = TimeSpan.FromSeconds(10);
    });

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<PetContext>();

var app = builder.Build();

//Code to auto migrate
// var db = app.Services.CreateScope().ServiceProvider.GetRequiredService<PetContext>();
// db.Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapIdentityApi<IdentityUser>();
app.UseAuthentication();
app.UseAuthorization();
app.Run();