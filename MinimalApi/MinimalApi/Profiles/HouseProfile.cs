using AutoMapper;
using MinimalApi.Data;
using MinimalApi.Modules;

namespace MinimalApi.Profiles;

public class HouseProfile : Profile
{
    public HouseProfile() 
    {
        CreateMap<HouseEntity, HouseDto>();
        CreateMap<HouseDto, HouseEntity>();
        CreateMap<HouseEntity, HouseDetailsDto>();
        CreateMap<HouseDetailsDto, HouseEntity>();
        CreateMap<HouseForCreationDto, HouseEntity>();
    }
}
