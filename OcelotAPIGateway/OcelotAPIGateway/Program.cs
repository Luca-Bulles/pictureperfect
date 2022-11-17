using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using OcelotAPIGateway.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure CORS for the gateway:
const string corsPolicy = "cors-app-policy";
builder.Services.AddCors(c => c.AddPolicy(corsPolicy, corsPolicyBuilder =>
{
    corsPolicyBuilder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddOcelot(builder.Configuration);

// Add custom claim authorizer to project:
builder.Services.DecorateClaimAuthoriser();

// Add custom JWT authentication to our project:
builder.Services.ConfigureJWT(builder.Environment.IsDevelopment(), "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAnMIcRryPVQrDcJ1E/shPrb3Fog5Q0TEEGRTxUW+9YIL7QS4oGZXry0lSYOtiEGmjO0bvzccuYiTKKIx+gT6KsQcBzcRmQld+W59C379F0YkktKAp9BT8wj5bYTZuE3dWk7ZiQuwyHin8kkkQ5sdwCnlk7G29lu8RGL6TyqHIl3P+zKAqd5oBLkviwB0HPXwkpQIcS/ptKhW7vetvftXmsiAl/kOsOF9jgZ1n5niz2dgByEsI3CC23PoOJ6Eyz8BuLPZ3rvcdOnLH2toPHPTmT+7JS5lCPWIZZUeprbEFsz22JZH1Hzgkt8I9TDu+mmITE7KmLS8QOoHh7pAPTR41xwIDAQAB");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PicturePerfect-Keycloak", Version = "v1" });
    // Add security definition:
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT authorization header",
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference = new OpenApiReference{
                    Id = JwtBearerDefaults.AuthenticationScheme, //The name of the previously defined security scheme.
                    Type = ReferenceType.SecurityScheme
                }
            },new List<string>()
        }
    });
});

// Add Ocelot to the project with a config file.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();
app.Run();