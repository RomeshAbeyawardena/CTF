using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Resource;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Resource, Models.Resource>();
        CreateMap<Models.Resource, CTF.Features.Models.Resource>()
            .ReverseMap();
    }
}
