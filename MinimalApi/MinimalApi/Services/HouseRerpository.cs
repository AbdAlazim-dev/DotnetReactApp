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
        private readonly IMapper _mapper;

        public HouseRerpository(HouseDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            return new HouseDetailsDto(house.Id ,house.Address, house.Country, house.Description, house.Price, house.Photo);
        }
        public async Task<HouseDetailsDto> Add(HouseForCreationDto houseToAdd)
        {
            var houseEntity = _mapper.Map<HouseEntity>(houseToAdd);

            _context.Houses.Add(houseEntity);

            _context.SaveChanges();

            return _mapper.Map<HouseDetailsDto>(houseEntity);

        }
        public async Task<HouseDetailsDto> Update(HouseDetailsDto houseToUpdate)
        {
            var houseEntity = await _context.Houses.FindAsync(houseToUpdate.Id);
            if (houseEntity == null)
                throw new ArgumentException("Error while updating a hosue");

            var updatedEntity = _mapper.Map<HouseEntity>(houseToUpdate);

            _context.Entry(updatedEntity).State = EntityState.Modified;

            _context.SaveChanges();

            return _mapper.Map<HouseDetailsDto>(updatedEntity);
        }
        public async Task Delete(int houseId)
        {
            var houseToDeleteEntity = await _context.Houses.FindAsync(houseId);
            if (houseToDeleteEntity == null)
                throw new ArgumentException($"House with id {houseId} was not found");

            _context.Houses.Remove(houseToDeleteEntity);
            await _context.SaveChangesAsync();
        }
    }
}
