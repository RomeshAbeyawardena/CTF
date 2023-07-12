using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Resource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Resource, Resource>();
        CreateMap<Resource, CTF.Features.Models.Resource>()
            .ReverseMap();
    }
}
