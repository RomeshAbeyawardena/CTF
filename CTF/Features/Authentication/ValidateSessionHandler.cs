using MediatR;

namespace CTF.Features.Authentication;

public class ValidateSessionHandler : IRequestHandler<ValidateSessionQuery, ValidationSessionResponse>
{

    public Task<ValidationSessionResponse> Handle(ValidateSessionQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
