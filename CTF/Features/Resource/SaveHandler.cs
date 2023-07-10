using AutoMapper;
using MediatR;
using RST.DependencyInjection.Extensions.Attributes;
using RST.Mediatr.Extensions;

namespace CTF.Features.Resource;

public class SaveHandler : RepositoryHandlerBase<SaveCommand, Models.Resource, Models.Resource>
{
    [Inject] protected IMediator? Mediator { get; set; }
    [Inject] protected IMapper? Mapper { get; set; }
    public SaveHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override async Task<Models.Resource> Handle(SaveCommand request, CancellationToken cancellationToken)
    {
        return await ProcessSave(request, Mapper!.Map<Models.Resource>, cancellationToken);
    }
}
