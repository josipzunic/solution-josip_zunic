using System.Text;
using AcademyTask.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

DotNetEnv.Env.TraversePath().Load();
var builder = WebApplication.CreateBuilder(args);

var secretKey = Environment.GetEnvironmentVariable("JWT_SECRET");
if (secretKey == null)
  throw new InvalidOperationException(
      "Please include the JWT_SECRET environment variable");

var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];

builder.Services
    .AddAuthentication(options => {
      options.DefaultAuthenticateScheme =
          JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options => {
      options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
      };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddOpenApi(options =>
{
  options.AddDocumentTransformer((document, context, cancellationToken) =>
  {
    document.Components ??= new();
    document.Components.SecuritySchemes.Add("Bearer", new()
    {
      Type = SecuritySchemeType.Http,
      Scheme = "bearer",
      BearerFormat = "JWT",
      In = ParameterLocation.Header,
      Description = "Enter your JWT token"
    });

    document.SecurityRequirements.Add(new()
    {
      [new OpenApiSecurityScheme
      {
        Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme }
      }] = Array.Empty<string>()
    });

    return Task.CompletedTask;
  });
});
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
  app.MapOpenApi();
  app.UseSwaggerUI(options => {
    options.SwaggerEndpoint("/openapi/v1.json", "AcademyTask API v1");
  });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
