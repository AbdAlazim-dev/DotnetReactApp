using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Modules;

namespace MinimalApi.Services;

public class BidRepository : IBidRerpository
{
    private readonly HouseDbContext _context;
    private readonly IMapper _mapper;

    public BidRepository(HouseDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<BidDto>> GetBidsForHouse(int houseId)
    {
        var bidsDtos = await _context.Bids.Where(bid => bid.HouseId == houseId)
            .Select(b => _mapper.Map<BidDto>(b))
            .ToListAsync();

        return bidsDtos;
    }
    public async Task<BidDto> AddBid(BidForCreationDto bid)
    {
        var bidEntity = _mapper.Map<BidEntity>(bid);

        _context.Bids.Add(bidEntity);

        await _context.SaveChangesAsync();

        return _mapper.Map<BidDto>(bidEntity);
    }
}
