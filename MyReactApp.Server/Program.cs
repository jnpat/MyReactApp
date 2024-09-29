using Microsoft.EntityFrameworkCore;
using MyReactApp.Server.BackgroundServices;
using MyReactApp.Server.Models;
using MyReactApp.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Connect DB
builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register HttpClient
builder.Services.AddHttpClient<ProductFetchService>();

// Register ProductSyncService
builder.Services.AddScoped<ProductSyncService>();

// Register ProductMappingService
builder.Services.AddScoped<ProductMappingService>();

// Register the background service
builder.Services.AddHostedService<ProductSyncBackgroundService>();

// Register ProductGetService
builder.Services.AddScoped<ProductGetService>();

// Register API controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
