// https://learn.microsoft.com/en-us/dotnet/core/extensions/options

namespace MakoCo.Predator
{

    public sealed class TestOptions
    {
        public bool Enabled { get; set; }
        public TimeSpan AutoRetryDelay { get; set; }
    }
}