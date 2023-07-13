using AutoMapper;

namespace CTF.Features.Transaction;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.Transaction>();
    }
}
