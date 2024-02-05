using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi;
using MinimalApi.Data;
using MinimalApi.Modules;
using MinimalApi.ServiceRegistration;
using MinimalApi.Services;
using MiniValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

//register the house and bid repository 
builder.Services.RegisterRepository();

//add auto mapper profiles
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//EF db context
builder.Services.AddDbContext<HouseDbContext>( o =>
{
    o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
    {
        options.WithOrigins("http://localhost:3000/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
}

//map house endpoints 
app.MapHouseEndPoints();

//map bids endpoints
app.MapBidEndpoints();




//Bid endpoints


app.UseHttpsRedirection();

app.Run();
