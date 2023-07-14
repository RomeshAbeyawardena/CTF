using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Client;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.Client, Models.Client>();
        CreateMap<Models.Client, CTF.Features.Models.Client>()
            .ReverseMap();
    }
}
