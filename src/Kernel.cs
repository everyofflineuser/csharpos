using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using src.kernel.consolesys;

namespace src.kernel
{
    public class Kernel : Sys.Kernel
    {
        public static readonly string Version = "0.1";


        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Welcome to C# OS by everyofflineuser version 0.1");
        }

        protected override void Run()
        {
            Console.InputEncoding = Encoding.UTF8;
            ConsoleSYS.Write("$Kernel SHELL ", false, 3);
            ConsoleSYS.Write(">> ", false, 7);
            var cmd = Console.ReadLine();

            ConsoleSYS.Execute(cmd);
        }
    }
}
