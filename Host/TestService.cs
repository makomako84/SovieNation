using Microsoft.Extensions.Options;

namespace MakoCo.Predator
{
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
}