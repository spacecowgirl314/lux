using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace Lux
{
    class Program
    {
        static readonly DisplayConfiguration.PHYSICAL_MONITOR[] monitors = DisplayConfiguration.GetPhysicalMonitors(DisplayConfiguration.GetCurrentMonitor());

        // TODO: Check for support for contrast, brightness. Doesn't work on mine.
        static int Main(string[] args)
        {
            // example usage:
            // lux set --brightness 50 --monitor 0
            return Parser.Default.ParseArguments<SetOptions, GetOptions>(args)
                .MapResult(
                (SetOptions opts) => RunSetAndReturnExitCode(opts),
                (GetOptions opts) => RunGetAndReturnExitCode(opts),
                errs => 1);
        }

        static int RunSetAndReturnExitCode(SetOptions o)
        {
            Verbose verbose = new Verbose(o.Verbose);
            verbose.WriteLine($"Running in verbose mode.");
            verbose.WriteLine($"Found {monitors.Count()} monitors.");
            // out of bounds error here
            verbose.WriteLine($"Using monitor {o.MonitorIndex}, {monitors[o.MonitorIndex].szPhysicalMonitorDescription}.");

            // only accept reasonable values.
            if (o.Brightness >= 0 && o.Brightness <= 100 && o.MonitorIndex >= 0 && o.MonitorIndex < monitors.Count())
            {
                verbose.WriteLine($"Setting brightness to {o.Brightness}.");
                // brightness must be a double. cast or this doesn't work
                DisplayConfiguration.SetMonitorBrightness(monitors[o.MonitorIndex], (double)o.Brightness/ 100);
            }
            else
            {
                Console.WriteLine("Brightness value must be between 0-100.");
                return 1;
            }

            if (o.Contrast >= 0 && o.Contrast <= 100 && o.MonitorIndex >= 0 && o.MonitorIndex < monitors.Count())
            {
                verbose.WriteLine($"Setting contrast to {o.Contrast}.");
                // contrast must be a double. cast or this doesn't work
                DisplayConfiguration.SetMonitorContrast(monitors[o.MonitorIndex], (double)o.Contrast / 100);
            }
            else
            {
                Console.WriteLine("Contrast value must be between 0-100.");
                return 1;
            }

            return 0;
        }

        static int RunGetAndReturnExitCode(GetOptions o)
        {
            Verbose verbose = new Verbose(o.Verbose);
            verbose.WriteLine($"Running in verbose mode.");
            verbose.WriteLine($"Found {monitors.Count()} monitors.");    
            
            // only accept reasonable values
            if (o.MonitorIndex >= 0 && o.MonitorIndex < monitors.Count())
            {
                verbose.WriteLine($"Using monitor {o.MonitorIndex}, {monitors[o.MonitorIndex].szPhysicalMonitorDescription}.");

                if (o.Brightness)
                {
                    verbose.WriteLine("Getting brightness.");
                    double brightness = DisplayConfiguration.GetMonitorBrightness(monitors[o.MonitorIndex]) * 100;
                    Console.WriteLine(brightness);

                    return 0;
                }

                if (o.Contrast)
                {
                    verbose.WriteLine("Getting contrast.");
                    double contrast = DisplayConfiguration.GetMonitorContrast(monitors[o.MonitorIndex]) * 100;
                    Console.WriteLine(contrast);

                    return 0;
                }
            }

            return 1;
        }
    }
}
