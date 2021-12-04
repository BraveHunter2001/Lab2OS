using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OS
{
    class Program
    {
        static MemoryInfo memoryInfo = new MemoryInfo();
        static MemRegionManager regionManager = new MemRegionManager();

        static Menu menu = new Menu("Main menu",
            new IMenuItem[]
            {
                new Menu("Memory INFO", new IMenuItem[] {
                    new MenuItem("SystemInfo", memoryInfo.PrintSystemInfo),
                    new MenuItem("Global Memory Status", memoryInfo.PrintGlobalMemoryStatus)
                }),
                new Menu("Memory Region Manager", new IMenuItem[] {
                    new Menu("Alloc mem region", new IMenuItem[]{
                        new MenuItem("Physical Auto", regionManager.ReservePhysicalAuto),
                        new MenuItem("Physical (with start adr)", regionManager.ReservePhysicalManual),
                        new MenuItem("Virtual Auto", regionManager.ReserveVirtualAuto),
                        new MenuItem("Virtual (with start adr)", regionManager.ReserveVirtualManual)
                    }),

                    new MenuItem("Determine segment mem", regionManager.DetermineStateSegMem),

                    Menu.CreateFromEnum<winapiFlags.MemoryProtection>("Set Protect region", regionManager.ProtectRegion),
                    new MenuItem("Free region mem",regionManager.FreeRegion)
                }),

            });
        static void Main(string[] args)
        {
            
            menu.Select();
        }
    }
}
