using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OS
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryInfo memInfo = new MemoryInfo();
            memInfo.PrintSystemInfo();
            Console.WriteLine("");
            memInfo.PrintGlobalMemoryStatus();
            Console.ReadLine();
        }
    }
}
