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
            MemRegionManager mem = new MemRegionManager();
            mem.ReserveVirtualAuto();
            mem.DetermineStateSegMem();
            mem.FreeRegion();
          
            Console.ReadLine();
        }
    }
}
