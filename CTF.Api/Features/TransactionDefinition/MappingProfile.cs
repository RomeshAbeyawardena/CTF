using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.TransactionDefinition;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.TransactionDefinition.TransactionDefinition, TransactionDefinition>();
        CreateMap<TransactionDefinition, CTF.Features.TransactionDefinition.TransactionDefinition>()
            .ReverseMap();
    }
}
