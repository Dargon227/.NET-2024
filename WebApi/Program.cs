using BusinessLayer.BLs;
using BusinessLayer.IBLs;
using DAL;
using DAL.DALs;
using DAL.IDALs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Inyección de dependencias */

#region Inyeccion

// Dals
builder.Services.AddTransient<IDAL_Personas, DAL_Personas_EF>();

// BLs
builder.Services.AddTransient<IBL_Persona, BL_Persona>();


#endregion


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

//Falta debcontext
DBContext.UpdateDatabase();

app.Run();
