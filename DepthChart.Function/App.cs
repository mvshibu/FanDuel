using CommandLine;
using DepthChart.Function.InputParser;
using DepthChart.Function.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DepthChart.Function
{

    public class App
    {
        private readonly ILogger<App> logger;
        private readonly IConfiguration config;
        private readonly IDepthChartFactory depthChartFactory;

        public App(ILogger<App> logger, IConfiguration config, IDepthChartFactory depthChartFactory)
        {
            this.config = config;
            this.logger = logger;
            this.depthChartFactory = depthChartFactory;
        }

        public void Run(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(this.RunOptions)
                .WithNotParsed(this.HandleParseError);

        }

        private void RunOptions(Options opts)
        {
            try
            {
                if (!string.IsNullOrEmpty(opts.Action))
                {
                    var nflDepthChartService = this.depthChartFactory.GetDepthChartServiceForSoprt("NFL");
                    switch (opts.Action)
                    {
                        case "add":
                            var addModel = JsonConvert.DeserializeObject<AddDataModel>(opts.Param);
                            if (addModel != null)
                                nflDepthChartService.AddPlayerToDepthChart(addModel.position, addModel.player.ToPlayerModel(), addModel.depth);
                            break;
                        case "remove":
                            var removeModel = JsonConvert.DeserializeObject<RBDataModel>(opts.Param);
                            if (removeModel != null)
                            {
                                var removePlayer = nflDepthChartService.RemovePlayerFromDepthChart(removeModel.position, removeModel.player.ToPlayerModel());
                                Console.WriteLine(removePlayer);
                            }
                            break;
                        case "backup":
                            var bckModel = JsonConvert.DeserializeObject<RBDataModel>(opts.Param);
                            if (bckModel != null)
                            {
                                var backupPlayers = nflDepthChartService.GetBackups(bckModel.position, bckModel.player.ToPlayerModel());
                                backupPlayers.ForEach(b => Console.WriteLine(b));
                            }
                            break;
                        case "full":
                            var fullPlayers = nflDepthChartService.GetFullDepthChart();
                            fullPlayers.ForEach(p => Console.WriteLine(p));
                            break;
                        default:
                            Console.WriteLine("Not valid action.");
                            break;
                    }
                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }

        }
        private void HandleParseError(IEnumerable<Error> errs)
        {

        }
    }
}