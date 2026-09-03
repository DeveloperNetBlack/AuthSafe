using AuthSafe.ApplicationService;
using AuthSafe.Infrastructure.GeneralService;
using AuthSafe.Infrastructure.DB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Añadir servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sg =>
{
    sg.EnableAnnotations();
});

var JWTConfigurationSection = builder.Configuration.GetSection("JWTToken");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    JWTConfigurationSection.Bind(
                        options.TokenValidationParameters);

                    options.TokenValidationParameters
                           .IssuerSigningKey = new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(
                    JWTConfigurationSection["SecurityKey"]!));
                });

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSigCoraApplicationService();
builder.Services.AddSigCoraInfrastructureGeneralService();
builder.Services.AddAuthSafeInfrastructureDB(builder.Configuration, "ConnectionStrings");
builder.Services.AddAuthSafeInfrastructureDB(builder.Configuration, "Security");

var app = builder.Build();

// Habilitar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
