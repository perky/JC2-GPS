using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace JC2GPSServer
{

    /// <summary>
    /// ProcessMemoryReader is a class that enables direct reading a process memory
    /// </summary>
    class ProcessMemoryReaderApi
    {
        // constants information can be found in <winnt.h>
        public const uint PROCESS_VM_READ = (0x0010);

        // function declarations are found in the MSDN and in <winbase.h> 

        //		HANDLE OpenProcess(
        //			DWORD dwDesiredAccess,  // access flag
        //			BOOL bInheritHandle,    // handle inheritance option
        //			DWORD dwProcessId       // process identifier
        //			);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        //		BOOL CloseHandle(
        //			HANDLE hObject   // handle to object
        //			);
        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);

        //		BOOL ReadProcessMemory(
        //			HANDLE hProcess,              // handle to the process
        //			LPCVOID lpBaseAddress,        // base of memory area
        //			LPVOID lpBuffer,              // data buffer
        //			SIZE_T nSize,                 // number of bytes to read
        //			SIZE_T * lpNumberOfBytesRead  // number of bytes read
        //			);
        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);
    }

    public class ProcessMemoryReader
    {

        public ProcessMemoryReader()
        {
        }

        /// <summary>	
        /// Process from which to read		
        /// </summary>
        public Process ReadProcess
        {
            get
            {
                return m_ReadProcess;
            }
            set
            {
                m_ReadProcess = value;
            }
        }

        private Process m_ReadProcess = null;

        private IntPtr m_hProcess = IntPtr.Zero;

        public void OpenProcess()
        {
            m_hProcess = ProcessMemoryReaderApi.OpenProcess(ProcessMemoryReaderApi.PROCESS_VM_READ, 1, (uint)m_ReadProcess.Id);
        }

        public void CloseHandle()
        {
            int iRetValue;
            iRetValue = ProcessMemoryReaderApi.CloseHandle(m_hProcess);
            if (iRetValue == 0)
                throw new Exception("CloseHandle failed");
        }

        public byte[] ReadProcessMemory(IntPtr MemoryAddress, uint bytesToRead, out int bytesReaded)
        {
            byte[] buffer = new byte[bytesToRead];

            IntPtr ptrBytesReaded;
            ProcessMemoryReaderApi.ReadProcessMemory(m_hProcess, MemoryAddress, buffer, bytesToRead, out ptrBytesReaded);

            bytesReaded = ptrBytesReaded.ToInt32();

            return buffer;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
