using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Policy;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Policy, Models.Policy>();
        CreateMap<Models.Policy, CTF.Features.Models.Policy>()
            .ReverseMap();
    }
}
