using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Policy;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Policy, Policy>();
        CreateMap<Policy, CTF.Features.Models.Policy>()
            .ReverseMap();
    }
}
