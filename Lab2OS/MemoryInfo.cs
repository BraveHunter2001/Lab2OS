using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using winapiFlags;

namespace Lab2OS
{
   public  class MemoryInfo
    {
        #region dll
        [DllImport("kernel32")]
        protected static extern uint GetLastError();

        [DllImport("kernel32", SetLastError = true)]
        protected static extern void GetSystemInfo(out SYSTEM_INFO_WCE50 lpSystemInfo);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);
        
        #endregion

        protected void PrintSystemInfo()
        {
            GetSystemInfo(out SYSTEM_INFO_WCE50 sysInfo);

            uint err;
            err = GetLastError();
            if (err != 0 )
            {
                Console.WriteLine($"ERROR. CODE:{err}");
                return;
            }

            Console.WriteLine($"ProcessorArchitecture: {(ProcessorArchitecture)sysInfo.wProcessorArchitecture}");
            Console.WriteLine($"ProcessorLevel: {sysInfo.wProcessorLevel}");
            Console.WriteLine($"ProcessorType: {sysInfo.dwProcessorType}");
            Console.WriteLine($"ProcessorRevision: {sysInfo.wProcessorRevision}");
            Console.WriteLine($"NumberOFProcessors: {sysInfo.dwNumberOfProcessors}");
            Console.WriteLine($"ActiveProcessorMask: {Convert.ToString(sysInfo.dwActiveProcessorMask.ToInt32(), 2)}");

            Console.WriteLine($"MemPageSize: {sysInfo.dwPageSize}");
            Console.WriteLine($"Minimum accessible memory: {sysInfo.lpMinimumApplicationAddress}");
            Console.WriteLine($"Maximum accessible memory: {sysInfo.lpMaximumApplicationAddress}");
            Console.WriteLine($"Allocation granularity: {sysInfo.dwAllocationGranularity}");
        }

        protected void PrintGlobalMemoryStatus()
        {
            MEMORYSTATUSEX ms = new MEMORYSTATUSEX();
            if (!GlobalMemoryStatusEx(ms))
            {
                uint err;
                err = GetLastError();
                if (err != 0)
                {
                    Console.WriteLine($"ERROR. CODE:{err}");
                    return;
                }
                return;
            }


            Console.WriteLine($"Mem load: {ms.dwMemoryLoad} %");
            Console.WriteLine($"Total Physical:{ms.ullTotalPhys/ (1024 * 1024)} mb ");
            Console.WriteLine($"Available Physical: {ms.ullAvailPhys / (1024 * 1024)} mb");
            Console.WriteLine($"Total Page File: {ms.ullTotalPageFile / (1024 * 1024)} mb");
            Console.WriteLine($"Available Page File: {ms.ullAvailPageFile / (1024 * 1024)} mb");
            Console.WriteLine($"Total Virtual: {ms.ullTotalVirtual / (1024 * 1024)} mb");
            Console.WriteLine($"Available Virtual: {ms.ullAvailVirtual / (1024*1024)} mb");
        }


    }
}
