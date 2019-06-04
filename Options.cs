using CommandLine;

namespace Lux
{
    class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }
    }

    [Verb("set", HelpText = "Set mode")]
    class SetOptions : Options
    {
        [Option("brightness", Required = false, HelpText = "Brightness value between 0-100")]
        public int? Brightness { get; set; }

        [Option("contrast", Required = false, HelpText = "Contrast value between 0-100")]
        public int? Contrast { get; set; }

        [Option("monitor", Required = false, HelpText = "Physical monitor")]
        public int MonitorIndex { get; set; }
    }

    [Verb("get", HelpText = "Get mode")]
    class GetOptions : Options
    {
        [Option("brightness", Required = false, HelpText = "Brightness value between 0-100")]
        public bool Brightness { get; set; }

        [Option("contrast", Required = false, HelpText = "Contrast value between 0-100")]
        public bool Contrast { get; set; }

        [Option("monitor", Required = false, HelpText = "Physical monitor")]
        public int MonitorIndex { get; set; }
    }
}
