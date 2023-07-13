using AutoMapper;

namespace CTF.Features.TransactionDefinition;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetPagedQuery, GetQuery>();
        CreateMap<SaveCommand, Models.TransactionDefinition>();
    }
}
