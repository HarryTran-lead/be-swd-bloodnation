using Microsoft.EntityFrameworkCore;
using BloodDonation_SWD.Controllers; // This line is likely still incorrect for DbContext namespace
using BloodDonation_SWD.Models; // You'll likely need the models namespace here as well

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BloodDonation_SWD.Models.BloodDonationContext>(options => // Assuming BloodDonationContext is in the Models namespace
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();