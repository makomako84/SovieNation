// https://learn.microsoft.com/en-us/dotnet/core/extensions/options

namespace MakoSystems.Sovienation.Host;
public class TestOptions
{
    public bool Enabled { get; set; }
    public TimeSpan AutoRetryDelay { get; set; }
}

public sealed class TransientFaultHandlingOptions
{
    public bool Enabled { get; set; }
    public TimeSpan AutoRetryDelay { get; set; }
}