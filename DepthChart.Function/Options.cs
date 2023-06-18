namespace DepthChart.Function
{
    using CommandLine;
    using CommandLine.Text;

    public class Options
    {
        // Models a command line value.
        [Value(0, MetaName = "action", Required = true, HelpText = "Depth Chart action to perform")]
        public string Action { get; set; }

        // Usage provide meta data for help screen.
        [Usage(ApplicationAlias = "DepthChart")]
        public static IEnumerable<Example> Examples => new List<Example>
        {
            new Example("Depth chart operations",
                new Options { Action = "add" })
        };
    }
}
