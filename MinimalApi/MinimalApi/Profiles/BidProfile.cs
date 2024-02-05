using AutoMapper;
using MinimalApi.Data;
using MinimalApi.Modules;

namespace MinimalApi.Profiles;

public class BidProfile : Profile
{
    public BidProfile() 
    {
        CreateMap<BidEntity, BidDto>();
        CreateMap<BidForCreationDto, BidEntity>();
        CreateMap<BidEntity, BidForCreationDto>();
    }
}
