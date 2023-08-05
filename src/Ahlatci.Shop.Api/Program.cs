using Ahlatci.Shop.Api.Filters;
using Ahlatci.Shop.Application.AutoMappings;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Service.Implementation;
using Ahlatci.Shop.Application.Validators.Categories;
using Ahlatci.Shop.Domain.Entites;
using Ahlatci.Shop.Domain.Repositories;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Persistence.Context;
using Ahlatci.Shop.Persistence.Repositories;
using Ahlatci.Shop.Persistence.UWork;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Reflection;
using System.Text;
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

builder.Services.AddSwaggerGen(opt =>
{
	//githubdan alınacak

});

//DbContext Registiration
builder.Services.AddDbContext<AhlatciContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("AhlatciShop"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



//Business Service Registiration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//fluent validation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		   .AddJwtBearer(options =>
		   {
			   options.TokenValidationParameters = new TokenValidationParameters
			   {
				   ValidateIssuer = true,
				   ValidateAudience = true,
				   ValidateLifetime = true,
				   ValidateIssuerSigningKey = true,
				   ValidIssuer = builder.Configuration["Jwt:Issuer"], // JWT üreten tarafın adı
				   ValidAudience = builder.Configuration["Jwt:Audiance"], // JWT'nin kullanılacağı alan adı
				   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigninKey"])) // Gizli anahtar
			   };
		   });

//unitofwork registiration
builder.Services.AddScoped<IUnitWork, UnitWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();