using CTF.Features.Initalisation;
using MediatR;
using RST.Contracts;

namespace CTF.Features.Initialisation;

public record InitialiseCommand : IRequest<InitialisationResult>, IDbCommand
{
    public IEnumerable<string>? ExcludedNamespaces { get; set; }
    public IEnumerable<string>? ExcludedResources { get; set; }
    public bool CommitChanges { get; set; }
}
