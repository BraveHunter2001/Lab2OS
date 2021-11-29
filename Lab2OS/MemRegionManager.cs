using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using winapiFlags;

namespace Lab2OS
{
	class MemRegionManager: MemoryInfo
	{

		#region dll 
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
		protected static extern IntPtr VirtualQuery(IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, IntPtr dwLength);

		[DllImport("kernel32")]
		public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, ExactSpelling = true)]
		protected static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

		[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, ExactSpelling = true)]
		protected static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, uint newProtect, [Out] out uint oldProtect);
		
		#endregion

		private static bool TryParseHex(string hex, out ulong result)
		{
			result = 0;
			if (hex == null)
				return false;
			try
			{
				if (hex.StartsWith("0x"))
					hex = hex.Substring(2);
				result = Convert.ToUInt64(hex, 16);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}


		protected ulong ConsoleReadHex()
		{
			Console.WriteLine("Input hex address:");
			ulong addr;
			while (!TryParseHex(Console.ReadLine(), out addr))
				Console.WriteLine("Incorrect hex number! Try again");
			return addr;
		}
		[STAThread]
		public void DetermineStateSegMem()
        {
			ulong addr = ConsoleReadHex();
			MEMORY_BASIC_INFORMATION buffer = new MEMORY_BASIC_INFORMATION();
			if ( (int)VirtualQuery((IntPtr)addr, out buffer, (IntPtr)Marshal.SizeOf(buffer)) != 0  )
			{
                Console.WriteLine($"AllocBase: {buffer.allocationBase}");
                Console.WriteLine($"AllocProtect: {buffer.allocationProtect}");
                Console.WriteLine($"Base address: {(MEM_ALLOCATION_PROTECT)buffer.baseAddress}");
                Console.WriteLine($"Region size: {buffer.regionSize}");
                Console.WriteLine($"State: {(MEM_STATE)buffer.state}");
                Console.WriteLine($"Type: {(MEM_TYPE)buffer.lType}");
            }
			else
            {
				Console.WriteLine($"Error: {GetLastError()}");
            }
					

  
        }

		public void FreeRegion()
		{
			ulong addr = ConsoleReadHex();
			if (VirtualFree((IntPtr)addr, 0, (uint)MEM_FREE_TYPE.MEM_RELEASE))
				Console.WriteLine("Memory freed successfully!");
			else
			{
				uint err = GetLastError();
				Console.WriteLine("Error " + (err != 0 ? $" Error code : {err}" : ""));
			}
		}

		bool AllocRegion(out IntPtr basicAddr, bool automatic = true, bool physical = false)
		{
			GetSystemInfo(out SYSTEM_INFO_WCE50 info);
			ulong addr = 0;
			if (!automatic)
				addr = ConsoleReadHex();
			uint memst = (uint)MEM_STATE.MEM_RESERVE;
			if (physical)
				memst |= (uint)MEM_STATE.MEM_COMMIT;
            

			basicAddr = VirtualAlloc((IntPtr)addr, info.dwPageSize,
				memst, (uint)MEM_ALLOCATION_PROTECT.PAGE_EXECUTE_READWRITE);
			uint err;
			if ((err = GetLastError()) != 0)
			{
				Console.WriteLine($" Error code: {err}");
				return false;
			}
			return true;
		}

		public void ReservePhysicalAuto()
		{
			if (AllocRegion(out IntPtr basicAddr, physical: true))
				Console.WriteLine($"Automatic physical allocation successful! Base address: 0x{basicAddr.ToInt64():X}");
		}

		public void ReservePhysicalManual()
		{
			if (AllocRegion(out IntPtr basicAddr, automatic: false, physical: true))
				Console.WriteLine($"Manual physical allocation successful! Base address: 0x{basicAddr.ToInt64():X}");
		}

		public void ReserveVirtualAuto()
		{
			if (AllocRegion(out IntPtr basicAddr))
				Console.WriteLine($"Automatic virtual allocation successful! Base address: 0x{basicAddr.ToInt64():X}");
		}

		public void ReserveVirtualManual()
		{
			if (AllocRegion(out IntPtr basicAddr, automatic: false))
				Console.WriteLine($"Manual virtual allocation successful! Base address: 0x{basicAddr.ToInt64():X}");
		}
	}
}
