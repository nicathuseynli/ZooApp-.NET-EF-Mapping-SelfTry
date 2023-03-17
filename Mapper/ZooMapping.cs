using AutoMapper;
using ZooApp_EF.Data.Entity;
using ZooApp_EF.Dto;
namespace ZooApp_EF.Mapper;
public class ZooMapping:Profile
{
    public ZooMapping()
    {
        CreateMap<Animal,AnimalDto>();
        CreateMap<Animal,AnimalDto>().ReverseMap();
        CreateMap<Cage,CageDto>();
        CreateMap<Cage,CageDto>().ReverseMap();
        CreateMap<Zoo,ZooDto>();
        CreateMap<Zoo,ZooDto>().ReverseMap();
    }
}
