using AutoMapper;
using RST.Automapper.Extensions;

namespace CTF.Api.Features.Transaction;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreatePagedMapping<CTF.Features.Transaction.Transaction, Transaction>();
        CreateMap<Transaction, CTF.Features.Transaction.Transaction>()
            .ReverseMap();
    }
}
