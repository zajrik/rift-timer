using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace rift_timer
{
    class DebugConsole
    {
        public DebugConsole() { }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern Boolean AllocConsole();

        public void Show()
        {
            AllocConsole();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
