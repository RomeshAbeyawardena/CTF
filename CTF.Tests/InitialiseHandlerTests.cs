using CTF.Features.Initalisation;
using CTF.Features.Initialisation;
using CoreModels = CTF.Features.Models;
using CTF.Models;
using MediatR;
using Moq;
using RST.Contracts;
using System.Data;

namespace CTF.Tests;

[TestFixture]
public class InitialiseHandlerTests
{
    [Test]
    public async Task Handle_WithEmptyExcludedNamespacesAndResourcesAndCommitChangesTrue_ShouldInsertAllNamespacesAndReturnNewResources()
    {
        // Arrange
        var request = new InitialiseCommand
        {
            ExcludedNamespaces = new string[0],
            ExcludedResources = new string[0],
            CommitChanges = true
        };
        var cancellationToken = new CancellationToken();
        var existingResources = new IResource[]
        {
        new CoreModels.Resource { Name = "Resource1", Description = "Description1", IsAvailable = true },
        new CoreModels.Resource { Name = "Resource2", Description = "Description2", IsAvailable = false }
        };
        var newResources = new CoreModels.Resource[]
        {
        new CoreModels.Resource { Name = "Namespace1", Description = "Namespace1 (Imported on 2023-07-14)", IsAvailable = true },
        new CoreModels.Resource { Name = "Namespace2", Description = "Namespace2 (Imported on 2023-07-14)", IsAvailable = true }
        };
        var expectedSql = "INSERT INTO [Resource] ([Id],[Name],[Description],[IsAvailable],[ImportedDate]) VALUES" +
                          "(NEWID(), 'Namespace1', 'Namespace1 (Imported on 2023-07-14)', 1, GETUTCDATE())," +
                          "(NEWID(), 'Namespace2', 'Namespace2 (Imported on 2023-07-14)', 1, GETUTCDATE())";
        var expectedResult = new InitialisationResult
        {
            ExistingResources = existingResources,
            NewResources = newResources
        };
        var mockMediator = new Mock<IMediator>();
        var mockQuery = new Mock<IQueryable<CoreModels.Resource>>();
        var mockClockProvider = new Mock<IClockProvider>();
        var mockConnection = new Mock<IDbConnection>();
        var mockServiceProvider = new Mock<IServiceProvider>();
        mockMediator.Setup(m => m.Send(It.IsAny<Features.Resource.GetQuery>(), cancellationToken)).ReturnsAsync(mockQuery.Object);
        //mockQuery.Setup(q => q.ToArrayAsync(cancellationToken)).ReturnsAsync(existingResources).Verifiable();
        mockClockProvider.Setup(c => c.UtcNow).Returns(new DateTime(2023, 7, 14));
        //mockConnection.Setup(c => c.ExecuteAsync(expectedSql)).ReturnsAsync(2).Verifiable();
        
        var handler = new InitialiseHandler(mockServiceProvider.Object);

        // Act
        var actualResult = await handler.Handle(request, cancellationToken);

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
        mockQuery.Verify();
        mockConnection.Verify();
    }
}
