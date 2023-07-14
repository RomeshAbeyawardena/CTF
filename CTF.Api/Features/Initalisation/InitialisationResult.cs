﻿using CTF.Models;

namespace CTF.Api.Features.Initalisation;

public record InitialisationResult : IInitialisationResult
{
    public InitialisationResult()
    {
        ExistingFeatures = new List<string>();
        NewFeatures = new List<string>();
    }

    public IEnumerable<string> ExistingFeatures { get; set; }
    public IEnumerable<string> NewFeatures { get; set; }
}