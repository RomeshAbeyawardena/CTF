using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.TransactionType;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Models.TransactionType, Models.TransactionType>();
        CreateMap<Models.TransactionType, CTF.Features.Models.TransactionType>()
            .ReverseMap();
    }
}
