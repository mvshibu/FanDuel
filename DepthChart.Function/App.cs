using CommandLine;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DepthChart.Function
{

    public class App
    {
        private readonly ILogger<App> logger;
        private readonly IConfiguration config;

        public App(ILogger<App> logger, IConfiguration config)
        {
            this.config = config;
            this.logger = logger;
        }

        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(this.RunOptions)
                .WithNotParsed(this.HandleParseError);
        }

        private void RunOptions(Options opts)
        {
            Console.WriteLine("Awesome CLI ⚡ 1.0.0");
            //Console.WriteLine("props= {0}", string.Join(",", opts.Props));
        }
        private void HandleParseError(IEnumerable<Error> errs)
        {

        }
    }
}