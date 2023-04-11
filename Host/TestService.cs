using Microsoft.Extensions.Options;

namespace MakoSystems.Sovienation.Host;
public class TestService
{
    private readonly TestOptions _options;
    public TestService(
        IOptions<TestOptions> options)
    {
        _options = options.Value;
    }

    public void TestValues()
    {
        Console.WriteLine($"TestOptions.Enabled={_options.Enabled}");
        Console.WriteLine($"TestOptions.AutoRetryDelay={_options.AutoRetryDelay}");
    }
}