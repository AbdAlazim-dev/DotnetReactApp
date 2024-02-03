using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Modules;
using SQLitePCL;

namespace MinimalApi.Services
{
    public class HouseRerpository : IHouseRepository
    {
        private readonly HouseDbContext _context;
        public HouseRerpository(HouseDbContext context)
        {
            _context = context;
        }
        public async Task<List<HouseEntity>> GetAllHouses()
        {
            var houses = await _context.Houses.ToListAsync();

            return houses;
        }

        public async Task<HouseDetailsDto> GetHouse(int id)
        {
            var house = await _context.Houses.SingleOrDefaultAsync(h => h.Id == id);
            if(house == null)
            {
                return null;
            }

            return new HouseDetailsDto(house.Id, house.Address, house.Country, house.Description, house.Price, house.Photo);
        }
    }
}
