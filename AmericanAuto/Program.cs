using AmericanAuto.Database;
using AmericanAuto.Database.Core;
using AmericanAuto.Database.Entities;
using AmericanAuto.Database.Repository;
using AmericanAuto.Models.Authentication;
using AmericanAuto.Services.Interfaces;
using AmericanAuto.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AdminSettings>(builder.Configuration.GetSection("Admin"));
builder.Services.Configure<AuthenticationConfig>(builder.Configuration.GetSection("AuthenticationConfig"));

//Services
//builder.Services.RegisterApplicationServices();
builder.Services.AddScoped<ICustomerService<Customer>, CustomerService>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();

//Database
var connectionString = builder.Configuration.GetSection("ConnectionString").Value;
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(connectionString));


// Add services to the container.
var authenticationConfig = builder.Configuration.GetSection("AuthenticationConfig").Get<AuthenticationConfig>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationConfig.Key)),
            ValidateIssuer = false,
            //ValidIssuer = authenticationConfig.ValidIssuer,
            ValidateAudience = false,
            //ValidAudience = authenticationConfig.ValidAudience
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });

    // Add security definitions
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API American Auto v1");
});

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication(); // Authentication

app.UseAuthorization();

app.MapControllers();

app.Run();
