using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RiftTimer
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

        public void WriteLine
            (
                string text,
                [CallerLineNumber] int line = 0,
                [CallerMemberName] string caller = null
            )
        {
            Console.WriteLine(String.Format("[DEBUG] \"{0}\" at line {1} ({2})", text, line, caller));
        }
    }
}
