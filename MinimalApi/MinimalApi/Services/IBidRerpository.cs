using MinimalApi.Modules;

namespace MinimalApi.Services;

public interface IBidRerpository
{
    Task<List<BidDto>> GetBidsForHouse(int houseId);
    Task<BidDto> AddBid(BidForCreationDto bid);
}
