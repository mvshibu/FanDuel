# nullable disable
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DepthChart.Function;
using DepthChart.Function.Services;
using DepthChart.Function.Models;
using CommandLine;

var host = CreateHostBuilder(args).Build();

var app = host.Services.GetRequiredService<App>();

while (true)
{
    var opts = Console.ReadLine();
    if (opts != "exit")
    {
        args = opts.Split(" ");
        app.Run(args);
    }
    else
    {
        break;
    }
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices(
            (_, services) => services
                .AddSingleton<App>()
                .AddSingleton<IDepthChartFactory, DepthChartFactory>()
                .AddSingleton<INFLTeamModel, NFLTeamModel>()
                .AddSingleton<IDepthChartService, NFLDepthChartService>());
}
