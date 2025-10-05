using Application.Interfaces;
using Application.Services;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Security
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

//Services
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICustomFieldService, CustomFieldService>();

//Repositories
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ICustomFieldRepository, CustomFieldRepository>();

//Validators
builder.Services.AddValidatorsFromAssemblyContaining<SupplierValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ServiceValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CustomFieldValidator>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()

            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
