using Microsoft.AspNetCore.Mvc;
using MinimalApi.Data;
using MinimalApi.Modules;

namespace MinimalApi.Services;

public interface IHouseRepository
{

    Task<List<HouseEntity>> GetAllHouses();

    Task<HouseDetailsDto> GetHouse(int id);
    Task<HouseDetailsDto> Add(HouseForCreationDto houseToAdd);
    Task<HouseDetailsDto> Update(HouseDetailsDto houseToUpdate);
    Task Delete(int houseId);
}
