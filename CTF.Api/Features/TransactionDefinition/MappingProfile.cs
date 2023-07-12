using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.TransactionDefinition;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.TransactionDefinition, Models.TransactionDefinition>();
        CreateMap<Models.TransactionDefinition, CTF.Features.Models.TransactionDefinition>()
            .ReverseMap();
    }
}
