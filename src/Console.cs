using System;
using System.Linq;

namespace src.kernel.consolesys
{
    public class ConsoleSYS
    {
        private static ConsoleColor DefaultTextColor = ConsoleColor.White;

        public static void Write(string output, bool newline, short color = 0)
        {
            // NOT WORKING: Encoding not change. Cyrillic not supported.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Setting Color
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            // Checking New Line?
            if (newline) Console.WriteLine(output);
            else Console.Write(output);

            // Set Color to Default
            if (color != 0) Console.ForegroundColor = DefaultTextColor;
        }

        public static void Execute(string fullcmd)
        {
            // Remove the arguments from the cmd
            var cmd = fullcmd.Split(' ')[0];

            // Remove the command from the list of arguments
            var arguments = fullcmd.Split(' ').Skip(1).ToArray();

            // Command Handler
            switch (cmd)
            {
                // CORE !! DON'T TOUCH THIS !!
                case "kernel":
                    if (arguments.Length > 0)
                    {
                        if (arguments.Contains("-v") || arguments.Contains("--version")) Write($"Version Kernel: {Kernel.Version}", true, 3);
                        else if (arguments.Contains("-i")) Write($"CPU: {Cosmos.Core.CPU.GetCPUBrandString()}", true);
                        else if (arguments.Contains("-s") || arguments.Contains("--shutdown")) Cosmos.System.Power.Shutdown();
                        else Write("using: kernel [option] \nexample: kernel -v", true, 3);
                    }
                    else
                    {
                        Write("using: kernel [option] \nexample: kernel -v", true, 3);
                    }
                    break;

                // Clearing Console
                case "clr":
                    Console.Clear();
                    break;

                case "clear":
                    Console.Clear();
                    break;

                // When not found command
                default:
                    Write(fullcmd + ": Unknown command. Please contact us.", true, 4);
                    break;
            }
        }
    }
}
