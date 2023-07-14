using CTF.Features.Initialisation;

namespace CTF.Tests;

[TestFixture]
public class InitialiseHandlerTests
{
    [Test]
    public void GetNamespaces()
    {
        var namespaces = InitialiseHandler.GetNamespaces(new[] { 
            "Policy"
        });

        Assert.That(namespaces, Does.Not.Contain("Model"));
        Assert.That(namespaces, Does.Not.Contain("Policy"));
    }

    [Test]
    public void GetExcludedResources()
    {

    }
}
