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

        public async Task<HouseEntity> GetHouse(int id)
        {
            var house = await _context.Houses.Where(h => h.Id == id).FirstOrDefaultAsync();

            return house;
        }
    }
}
