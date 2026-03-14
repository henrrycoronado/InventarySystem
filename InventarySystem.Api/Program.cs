using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using InventarySystem.Api.src.Core.Infrastructure;
using InventarySystem.Api.src.Core.Infrastructure.Repositories;
using InventarySystem.Api.src.Core.Domain.Interfaces;
using InventarySystem.Api.src.Core.Application.Interfaces;
using InventarySystem.Api.src.Core.Application.Services;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IGlobalCategoryRepository, GlobalCategoryRepository>();
builder.Services.AddScoped<IGlobalProductRepository, GlobalProductRepository>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IGlobalCategoryService, GlobalCategoryService>();
builder.Services.AddScoped<IGlobalProductService, GlobalProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "InventarySystem API",
        Version = "v1",
        Description = "Multimodular SaaS inventory management API"
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "InventarySystem API v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseCors();
app.MapControllers();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    timestamp = DateTime.UtcNow
})).WithTags("Health");

app.Run();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    timestamp = DateTime.UtcNow
})).WithTags("Health");

app.Run();