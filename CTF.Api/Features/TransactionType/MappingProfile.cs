using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.TransactionType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.TransactionType.TransactionType, TransactionType>();
        CreateMap<TransactionType, CTF.Features.TransactionType.TransactionType>()
            .ReverseMap();
    }
}
