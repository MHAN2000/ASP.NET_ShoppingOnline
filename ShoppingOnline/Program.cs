using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Data;
using ShoppingOnline.Data.Repositories;
using ShoppingOnline.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<ITicketRepository, Ticketservice>();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
