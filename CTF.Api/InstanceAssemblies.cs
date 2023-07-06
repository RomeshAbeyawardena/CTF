namespace CTF.Api;

public static class InstanceAssemblies
{
    public const string CORE_ASSEMBLY = "CTF";
    public const string API_ASSEMBLY = "CTF.Api";
    public static IEnumerable<string> Names => new[] { CORE_ASSEMBLY, API_ASSEMBLY };
}
