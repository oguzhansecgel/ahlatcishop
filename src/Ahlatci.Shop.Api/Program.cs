using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Service.Implementation;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AhlatciContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AhlatciShop"));
});


//business servis registiration
builder.Services.AddScoped<ICategoryService, CategoryService>();




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
