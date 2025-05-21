using Microsoft.EntityFrameworkCore;
using BloodDonation_SWD.Models;

var builder = WebApplication.CreateBuilder(args);

// Log connection string
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("👉 Connection string: " + connStr);

// Add services
builder.Services.AddDbContext<BloodDonationContext>(options =>
    options.UseSqlServer(connStr));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

// Dùng PORT từ Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // tạm tắt nếu gặp lỗi cổng HTTPS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// Tự động migrate
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloodDonationContext>();
    db.Database.Migrate();
}

// Bọc app.Run trong try-catch
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(" ERROR during app startup: " + ex.Message);
    throw;
}
