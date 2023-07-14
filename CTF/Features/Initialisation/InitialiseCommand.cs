using CTF.Features.Initalisation;
using MediatR;

namespace CTF.Features.Initialisation;

public record InitialiseCommand : IRequest<InitialisationResult>
{
    public IEnumerable<string>? ExcludedFeatures { get; set; }
}
