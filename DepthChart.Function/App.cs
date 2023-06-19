using CommandLine;
using DepthChart.Function.InputParser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            if (!string.IsNullOrEmpty(opts.Action))
            {
                switch (opts.Action)
                {
                    case "add":
                        var addModel = JsonConvert.DeserializeObject<AddDataModel>(opts.Param);
                        Console.WriteLine(addModel?.position);
                        Console.WriteLine(addModel?.depth);
                        break;
                    case "remove":

                        break;
                    case "backup":

                        break;
                    case "full":

                        break;
                    default:
                        Console.WriteLine("Not valid action.");
                        break;
                }
            }
        }
        private void HandleParseError(IEnumerable<Error> errs)
        {

        }
    }
}