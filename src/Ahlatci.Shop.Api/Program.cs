﻿using Ahlatci.Shop.Application.AutoMappings;
using Ahlatci.Shop.Application.Service.Abstract;
using Ahlatci.Shop.Application.Service.Implementation;
using Ahlatci.Shop.Application.Validators.Categories;
using Ahlatci.Shop.Domain.Repositories;
using Ahlatci.Shop.Domain.Service.Abstract;
using Ahlatci.Shop.Domain.Service.Implementation;
using Ahlatci.Shop.Domain.UWork;
using Ahlatci.Shop.Persistence.Context;
using Ahlatci.Shop.Persistence.Repositories;
using Ahlatci.Shop.Persistence.UWork;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

//jwt tokenı onaylatmak için gerekli olan config 1 
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								}
							},
							new string[] {}
					}
				});
});

builder.Services.AddHttpContextAccessor();
//DbContext Registiration
builder.Services.AddDbContext<AhlatciContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("AhlatciShop"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



//Business Service Registiration
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ILoggedUserService, LoggedUserService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
//Automapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(ViewModelToDomain));

//fluent validation
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCategoryValidator));

//jwt token 2 
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
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"images")),
	RequestPath= new PathString("/images"),
});
app.Run();