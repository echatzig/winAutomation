using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SoftClient.Services
{

    /*
     *   example usage:
     *   

    WinAutoEngine eng = new WinAutoEngine();
    eng.SelectWindow("Google - Mozilla Firefox");
    //eng.SelectWindow("Untitled - Notepad");
    eng.SetCursor(560, 417); 
    eng.DoMouseClick();
    eng.SendKeys("today in wikipedia");
    //eng.SendKeys("{ENTER}");
    eng.SetCursor(560, 694); // 487);
    eng.DoMouseClick();

    */


    class WinAutoEngine
    {
        private IntPtr _selectedHWND = IntPtr.Zero;

        public void SendKeys(string str)
        {
            System.Windows.Forms.SendKeys.SendWait(str);
            Console.WriteLine($"SendKeys({str})");
        }

        public void SetCursor(int X, int Y)
        {
            Win32.POINT p = new Win32.POINT();
            p.x = X;
            p.y = Y;

            Win32.ClientToScreen(_selectedHWND, ref p);
            Win32.SetCursorPos(p.x, p.y);
            Console.WriteLine($"SetCursor({X},{Y})");
        }

        // returns the HWND of the window (if found), otherwise IntPtr.Zero
        public bool SelectWindow(string win_title)
        {
            _selectedHWND = Win32.FindWindow(null, win_title);
            if (_selectedHWND != IntPtr.Zero)
            {
                Win32.SetForegroundWindow(_selectedHWND);
                Console.WriteLine($"SelectWindow({win_title}): SUCCESS :: _selectedHWND={_selectedHWND}");
                return true;
            }
            Console.WriteLine($"SelectWindow({win_title}): FAILURE");
            return false;
        }


        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            Win32.mouse_event(Win32.MOUSEEVENTF_LEFTDOWN | Win32.MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            Console.WriteLine($"DoMouseClick");
        }
    }

    public class Win32
    {
        [DllImport("user32.Dll")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_MOVE = 0x0001;


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string sClass, string sWindow);

        /*
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        public static void PressKey(Keys key, bool up)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (up)
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            }
        }*/
    }

}
