using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Modules;
using MinimalApi.Services;
using MiniValidation;
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

    //To test the loading in the frontend
    Thread.Sleep(2000);

    return mapper.Map<List<HouseDto>>(houseEntities);
}).Produces<HouseDto[]>(StatusCodes.Status200OK);

//get house by its id
app.MapGet("/houses/{houseId:int}", async (
    int houseId,
    IHouseRepository houseRepository) =>
{
    var house = await houseRepository.GetHouse(houseId);

    if (house == null)
    {
        return Results.Problem($"there is no house with the id {houseId}", statusCode: StatusCodes.Status404NotFound);
    }

    Thread.Sleep(2000);
    return Results.Ok(house);
}).ProducesProblem(StatusCodes.Status404NotFound).Produces<HouseDetailsDto>(StatusCodes.Status200OK);


//Create new house by passing the house values on the request body
app.MapPost("/houses", async (
    IHouseRepository houaseRepository,
    [FromBody] HouseForCreationDto houseToAdd
    ) =>
{
    if(!MiniValidator.TryValidate(houseToAdd, out var errors))
    {
        return Results.ValidationProblem(errors);
    }
    var newHouse = await houaseRepository.Add(houseToAdd);

    return Results.Created($"houses/{newHouse.Id}", newHouse);

}).ProducesValidationProblem(StatusCodes.Status400BadRequest)
.Produces<HouseDetailsDto>(StatusCodes.Status201Created);

//Update a house using its id
app.MapPut("/houses", async (
    IHouseRepository houseRepository,
    [FromBody] HouseDetailsDto house) =>
{
    if (!MiniValidator.TryValidate(house, out var errors))
    {
        return Results.ValidationProblem(errors);
    }
    var houseToUpdate = houseRepository.GetHouse(house.Id);

    if (houseToUpdate == null)
        return Results.Problem($"There is no house with the id {house.Id}");

    var updatedHouse = await houseRepository.Update(house);

    return Results.Ok(updatedHouse);
}).ProducesValidationProblem(StatusCodes.Status400BadRequest).ProducesProblem(StatusCodes.Status404NotFound).Produces<HouseDetailsDto>(StatusCodes.Status200OK);

//Delete a house by its id
app.MapDelete("houses/{houseId}", async (
    IHouseRepository houseRepository,
    int houseId) =>
{

    if (await houseRepository.GetHouse(houseId) == null)
        return Results.Problem($"There is no house with id : {houseId}");

    await houseRepository.Delete(houseId);

    return Results.Ok();
}).ProducesProblem(StatusCodes.Status404NotFound).Produces(StatusCodes.Status200OK);

app.UseHttpsRedirection();

app.Run();
