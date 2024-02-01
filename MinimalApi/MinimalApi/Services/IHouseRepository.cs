using Microsoft.AspNetCore.Mvc;
using MinimalApi.Data;
using MinimalApi.Modules;

namespace MinimalApi.Services;

public interface IHouseRepository
{

    Task<List<HouseEntity>> GetAllHouses();

    Task<HouseEntity> GetHouse(int id);
}
