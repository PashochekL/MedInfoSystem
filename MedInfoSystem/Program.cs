using MedInfoSystem;
using MedInfoSystem.Data;
using MedInfoSystem.Data.Entities;
using MedInfoSystem.Services;
using MedInfoSystem.Services.IServices;
using MedInfoSystem.Services.MiddleWare;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };

        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

                if (authHeader != null && authHeader.StartsWith("Bearer "))
                {
                    var token = authHeader.Substring("Bearer ".Length).Trim();

                    if (token == null)
                    {
                        context.Fail("Invalid token");
                        return;
                    }

                    var blacklistService = context.HttpContext.RequestServices.GetRequiredService<TokenBlacklistService>();

                    try
                    {
                        if (blacklistService.IsTokenRevoked(token))
                        {
                            context.Fail("Token has been revoked");
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Fail("Internal server error");
                    }
                }
            }
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Project API", Version = "v1" });

    var securitySheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT token **Bearer {token}**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySheme);

    var securiryRequirement = new OpenApiSecurityRequirement
    {
        {securitySheme, new string[] {} }
    };
    c.AddSecurityRequirement(securiryRequirement);
});

builder.Services.AddControllers();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDictionaryService, DictionaryService>();
builder.Services.AddScoped<IConsultationService, ConsultationService>();
builder.Services.AddScoped<IInspectionService, InspectionService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<TokenBlacklistService>();
builder.Services.AddScoped<CsvDataLoaderService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDoctorService, DoctorService>();

var app = builder.Build();

var key = new byte[32];
using (var rng = RandomNumberGenerator.Create())
{
    rng.GetBytes(key);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    //app.UseDeveloperExceptionPage();
}
else
{
    app.UseMiddleware<ErrorHandlingMiddleware>(); // также добавьте для режима Production
}


app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

await LoadCsvDataAsync(app.Services);

app.MapControllers();

app.Run();

async Task LoadCsvDataAsync(IServiceProvider services)
{
    using (var scope = services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
        var csvLoader = scope.ServiceProvider.GetRequiredService<CsvDataLoaderService>();

        string filePath = @"C:\Users\Пользователь\source\repos\MedInfoSystem\MedInfoSystem\ICD\DirectoryICD.csv";
        await csvLoader.LoadCsvToDatabase(filePath);
    }
}