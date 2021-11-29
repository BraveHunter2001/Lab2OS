using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace winapiFlags
{
	
		public enum DriveType
		{
			UNKNOWN_TYPE,
			INVALID_PATH,
			DRIVE_REMOVABLE,
			DRIVE_FIXED,
			DRIVE_REMOTE,
			DRIVE_CDROM,
			DRIVE_RAMDISK
		}

		public enum FileSystemFlags : uint
		{
			FILE_CASE_PRESERVED_NAMES = 0x00000002,
			FILE_CASE_SENSITIVE_SEARCH = 0x00000001,
			FILE_FILE_COMPRESSION = 0x00000010,
			FILE_NAMED_STREAMS = 0x00040000,
			FILE_PERSISTENT_ACLS = 0x00000008,
			FILE_READ_ONLY_VOLUME = 0x00080000,
			FILE_SEQUENTIAL_WRITE_ONCE = 0x00100000,
			FILE_SUPPORTS_ENCRYPTION = 0x00020000,
			FILE_SUPPORTS_EXTENDED_ATTRIBUTES = 0x00800000,
			FILE_SUPPORTS_HARD_LINKS = 0x00400000,
			FILE_SUPPORTS_OBJECT_IDS = 0x00010000,
			FILE_SUPPORTS_OPEN_BY_FILE_ID = 0x01000000,
			FILE_SUPPORTS_REPARSE_POINTS = 0x00000080,
			FILE_SUPPORTS_SPARSE_FILES = 0x00000040,
			FILE_SUPPORTS_TRANSACTIONS = 0x00200000,
			FILE_SUPPORTS_USN_JOURNAL = 0x02000000,
			FILE_UNICODE_ON_DISK = 0x00000004,
			FILE_VOLUME_IS_COMPRESSED = 0x00008000,
			FILE_VOLUME_QUOTAS = 0x00000020,
			FILE_SUPPORTS_BLOCK_REFCOUNTING = 0x08000000
		}

		[StructLayout(LayoutKind.Sequential)]
		public class SECURITY_ATTRIBUTES
		{
			public uint length;
			public IntPtr securityDescriptor;
			public bool inheritHandle;
		}

		[StructLayout(LayoutKind.Sequential)]
		public class SYSTEMTIME
		{
			public ushort year;
			public ushort month;
			public ushort dayOfWeek;
			public ushort day;
			public ushort hour;
			public ushort minutes;
			public ushort seconds;
			public ushort milliseconds;
		}

		[StructLayout(LayoutKind.Sequential)]
		public class BY_HANDLE_FILE_INFORMATION
		{
			public uint fileAttributes;
			public FILETIME creationTime;
			public FILETIME lastAccessTime;
			public FILETIME lastWriteTime;
			public uint volumeSerialNumber;
			public uint fileSizeHigh;
			public uint fileSizeLow;
			public uint numberOfLinks;
			public uint fileIndexHigh;
			public uint fileIndexLow;
		}

		[Flags]
		public enum MoveFlags : uint
		{
			MOVEFILE_REPLACE_EXISTING = 1,
			MOVEFILE_COPY_ALLOWED = 2,
			MOVEFILE_DELAY_UNTIL_REBOOT = 4,
			MOVEFILE_WRITE_THROUGH = 8,
			MOVEFILE_CREATE_HARDLINK = 16,
			MOVEFILE_FAIL_IF_NOT_TRACKABLE = 32
		}

		[Flags]
		public enum ShareMode : uint
		{
			None = 0,
			FILE_SHARE_READ = 1,
			FILE_SHARE_WRITE = 2,
			FILE_SHARE_DELETE = 4
		}

		public enum CreationDisposition : uint
		{
			CREATE_NEW = 1,
			CREATE_ALWAYS = 2,
			OPEN_EXISTING = 3,
			OPEN_ALWAYS = 4,
			TRUNCATE_EXISTING = 5
		}

		public enum FileAttributes : uint
		{
			FILE_ATTRIBUTE_READONLY = 0x1,
			FILE_ATTRIBUTE_HIDDEN = 0x2,
			FILE_ATTRIBUTE_SYSTEM = 0x4,
			FILE_ATTRIBUTE_ARCHIVE = 0x20,
			FILE_ATTRIBUTE_NORMAL = 0x80,
			FILE_ATTRIBUTE_TEMPORARY = 0x100,
			FILE_ATTRIBUTE_OFFLINE = 0x1000,
			FILE_ATTRIBUTE_ENCRYPTED = 0x4000
		}
		public enum FileFlags : uint
		{
			FILE_FLAG_BACKUP_SEMANTICS = 0x02000000,
			FILE_FLAG_DELETE_ON_CLOSE = 0x04000000,
			FILE_FLAG_NO_BUFFERING = 0x20000000,
			FILE_FLAG_OPEN_NO_RECALL = 0x00100000,
			FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000,
			FILE_FLAG_OVERLAPPED = 0x40000000,
			FILE_FLAG_POSIX_SEMANTICS = 0x01000000,
			FILE_FLAG_RANDOM_ACCESS = 0x10000000,
			FILE_FLAG_SESSION_AWARE = 0x00800000,
			FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000,
			FILE_FLAG_WRITE_THROUGH = 0x80000000
		}

		public enum DesiredAccess : uint
		{
			GENERIC_READ = 0x80000000,
			GENERIC_WRITE = 0x40000000,
			GENERIC_EXECUTE = 0x20000000,
			GENERIC_ALL = 0x10000000
		}

		public enum EMoveMethod : uint
		{
			Begin = 0,
			Current = 1,
			End = 2
		}

	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_INFO_WCE50
	{
		public ushort wProcessorArchitecture;
		public byte wReserved;
		public uint dwPageSize;
		public IntPtr lpMinimumApplicationAddress;
		public IntPtr lpMaximumApplicationAddress;
		public IntPtr dwActiveProcessorMask;
		public uint dwNumberOfProcessors;
		public uint dwProcessorType;
		public uint dwAllocationGranularity;
		public ushort wProcessorLevel;
		public ushort wProcessorRevision;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class MEMORYSTATUSEX
	{
		public uint dwLength;
		public uint dwMemoryLoad;
		public ulong ullTotalPhys;
		public ulong ullAvailPhys;
		public ulong ullTotalPageFile;
		public ulong ullAvailPageFile;
		public ulong ullTotalVirtual;
		public ulong ullAvailVirtual;
		public ulong ullAvailExtendedVirtual;
		public MEMORYSTATUSEX()
		{
			dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
		}
	}

	public enum ProcessorArchitecture : int
	{
		PROCESSOR_ARCHITECTURE_AMD64 = 9,
		PROCESSOR_ARCHITECTURE_ARM = 5,
		PROCESSOR_ARCHITECTURE_ARM64 = 12,
		PROCESSOR_ARCHITECTURE_IA64 = 6,
		PROCESSOR_ARCHITECTURE_INTEL = 0,
		PROCESSOR_ARCHITECTURE_UNKNOWN = 0xFFFF
	}



	[StructLayout(LayoutKind.Sequential)]
	public struct MEMORY_BASIC_INFORMATION
	{
		public IntPtr baseAddress;
		public IntPtr allocationBase;
		public uint allocationProtect;
		public IntPtr regionSize;
		public uint state;
		public uint protect;
		public uint lType;
	}


	public enum MEM_ALLOCATION_PROTECT : uint
	{
		NO_ACCESS = 0,
		PAGE_EXECUTE = 0x00000010,
		PAGE_EXECUTE_READ = 0x00000020,
		PAGE_EXECUTE_READWRITE = 0x00000040,
		PAGE_EXECUTE_WRITECOPY = 0x00000080,
		PAGE_NOACCESS = 0x00000001,
		PAGE_READONLY = 0x00000002,
		PAGE_READWRITE = 0x00000004,
		PAGE_WRITECOPY = 0x00000008,
		PAGE_GUARD = 0x00000100,
		PAGE_NOCACHE = 0x00000200,
		PAGE_WRITECOMBINE = 0x00000400
	}

	public enum MEM_TYPE : uint
	{
		MEM_IMAGE = 0x1000000,
		MEM_MAPPED = 0x40000,
		MEM_PRIVATE = 0x20000
	}

	public enum MEM_STATE : uint
	{
		MEM_COMMIT = 0x1000,
		MEM_FREE = 0x10000,
		MEM_RESERVE = 0x2000,
	}
	public enum MEM_FREE_TYPE : uint
	{
		MEM_DECOMMIT = 0x00004000,
		MEM_RELEASE = 0x00008000,
		
		MEM_COALESCE_PLACEHOLDERS = 0x00000001,
		
		MEM_PRESERVE_PLACEHOLDER = 0x00000002
	}

	public enum MemoryProtection
	{
		NoAccess = 0x01,
		ReadOnly = 0x02,
		ReadWrite = 0x04,
		WriteCopy = 0x08,
		Execute = 0x10,
		ExecuteRead = 0x20,
		ExecuteReadWrite = 0x40,
		ExecuteWriteCopy = 0x80,
		GuardModifierflag = 0x100,
		NoCacheModifierflag = 0x200,
		WriteCombineModifierflag = 0x400,
		TargetsInvalid = 0x40000000
	}
}
