using System.Text;

namespace CTF.Tests
{
    [TestFixture]
    public class AssemblyTests
    {
        [Test]
        public void Test()
        {
            var namespaces = typeof(Instance).Assembly.GetTypes().Where(a => !string.IsNullOrWhiteSpace(a.Namespace) 
                && a.Namespace.StartsWith("CTF.Features") && !a.Namespace.EndsWith("Models"))
                .Select(a => { 
                    var n = a.Namespace!.Split('.'); 
                    return n[^1];
                }).OrderBy(a => a).Distinct().ToArray();

            Assert.That(namespaces, Is.Not.Empty);

            Assert.That(namespaces, Does.Contain("ActivityLog"));
            Assert.That(namespaces, Does.Contain("ActivityType"));
            Assert.That(namespaces, Does.Contain("Authentication"));
            Assert.That(namespaces, Does.Contain("Features"));
            Assert.That(namespaces, Does.Contain("Resource"));
            Assert.That(namespaces, Does.Contain("Session"));
            Assert.That(namespaces, Does.Contain("SessionAuthenticationToken"));
            Assert.That(namespaces, Does.Contain("Transaction"));
            Assert.That(namespaces, Does.Contain("TransactionDefinition"));
            Assert.That(namespaces, Does.Contain("TransactionType"));


            var sqlBuilder = new StringBuilder("INSERT INTO [Resource] ([Id],[Name],[Description],[IsAvailable],[ImportedDate]) VALUES ");
            bool isFirst = true;
            foreach (var @namespace in namespaces)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sqlBuilder.Append(',');
                }

                sqlBuilder.AppendLine($"(NEWID(), '{@namespace}', '{@namespace}', 1, GETUTCDATE())");
            }

            Assert.That(sqlBuilder.ToString(), 
                Is.EqualTo("INSERT INTO [Resource] ([Id],[Name],[Description],[IsAvailable],[ImportedDate]) VALUES (NEWID(), 'ActivityLog', 'ActivityLog', 1, GETUTCDATE())\r\n,(NEWID(), 'ActivityType', 'ActivityType', 1, GETUTCDATE())\r\n,(NEWID(), 'Authentication', 'Authentication', 1, GETUTCDATE())\r\n,(NEWID(), 'Features', 'Features', 1, GETUTCDATE())\r\n,(NEWID(), 'Resource', 'Resource', 1, GETUTCDATE())\r\n,(NEWID(), 'Session', 'Session', 1, GETUTCDATE())\r\n,(NEWID(), 'SessionAuthenticationToken', 'SessionAuthenticationToken', 1, GETUTCDATE())\r\n,(NEWID(), 'Transaction', 'Transaction', 1, GETUTCDATE())\r\n,(NEWID(), 'TransactionDefinition', 'TransactionDefinition', 1, GETUTCDATE())\r\n,(NEWID(), 'TransactionType', 'TransactionType', 1, GETUTCDATE())\r\n"));
        }
    }
}
