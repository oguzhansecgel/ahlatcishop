using Ahlatci.Shop.Api.Filters;
using Ahlatci.Shop.Application.AutoMappings;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Service.Implementation;
using Ahlatci.Shop.Application.Validators;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Persistence.Context;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Ahlatci.Shop.Api.Filters.ExceptionHandleFilters;

var builder = WebApplication.CreateBuilder(args);

//Logging
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
 

// Add services to the container.

//ActionFilter registiration
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//DbContext Registiration
builder.Services.AddDbContext<AhlatciContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AhlatciShop"));
});

//Business Service Registiration
builder.Services.AddScoped<ICategoryService, CategoryService>();

//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//fluent validation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));


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