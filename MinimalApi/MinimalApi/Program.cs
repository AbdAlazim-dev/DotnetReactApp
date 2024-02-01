using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Modules;
using MinimalApi.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddScoped<IHouseRepository, HouseRerpository>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
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

app.MapGet("/houses", async (
    IHouseRepository houseRepository,
    IMapper mapper) =>
{
    var houseEntities = await houseRepository.GetAllHouses();

    return mapper.Map<List<HouseDto>>(houseEntities);
});

//get house by its id
app.MapGet("/houses/{houseId}", async (
    int houseId,
    IHouseRepository houseRepository,
    IMapper mapper) =>
{
    var house = await houseRepository.GetHouse(houseId);

    return mapper.Map<HouseDto>(house);
});
app.UseHttpsRedirection();

app.Run();
