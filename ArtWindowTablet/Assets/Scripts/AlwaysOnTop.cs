



#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN


 


using UnityEngine;


using System;


using System.Collections;


using System.Collections.Generic;


using System.Drawing;


using System.Diagnostics;


using System.Runtime.InteropServices;
  

 


 


public class AlwaysOnTop : MonoBehaviour {


    #region WIN32API


 


    public static readonly System.IntPtr HWND_TOPMOST = new System.IntPtr(-1);


    public static readonly System.IntPtr HWND_NOT_TOPMOST = new System.IntPtr(-2);


    const System.UInt32 SWP_SHOWWINDOW = 0x0040;


 


    [StructLayout(LayoutKind.Sequential)]


    public struct RECT {


        public int Left, Top, Right, Bottom;


 


        public RECT(int left, int top, int right, int bottom) {


            Left = left;


            Top = top;


            Right = right;


            Bottom = bottom;


        }


 


        public RECT(System.Drawing.Rectangle r)


            : this(r.Left, r.Top, r.Right, r.Bottom) {


        }


 


        public int X {


            get {


                return Left;


            }


            set {


                Right -= (Left - value);


                Left = value;


            }


        }


 


        public int Y {


            get {


                return Top;


            }


            set {


                Bottom -= (Top - value);


                Top = value;


            }


        }


 


        public int Height {


            get {


                return Bottom - Top;


            }


            set {


                Bottom = value + Top;


            }


        }


 


        public int Width {


            get {


                return Right - Left;


            }


            set {


                Right = value + Left;


            }


        }


 


        public static implicit operator System.Drawing.Rectangle(RECT r) {


            return new System.Drawing.Rectangle(r.Left, r.Top, r.Width, r.Height);


        }


 


        public static implicit operator RECT(System.Drawing.Rectangle r) {


            return new RECT(r);


        }


    }


 


    [DllImport("user32.dll", SetLastError = true)]


    private static extern System.IntPtr FindWindow(String lpClassName, String lpWindowName);


 


    [DllImport("user32.dll")]


    [return: MarshalAs(UnmanagedType.Bool)]


    public static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);



    [DllImport("user32.dll")]

    [return: MarshalAs(UnmanagedType.Bool)]

    static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

    

    [DllImport("user32.dll", EntryPoint = "GetActiveWindow")]

    private static extern int GetActiveWindow();


    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]


   private static extern int SetWindowPos(int hwnd, int hwndInsertAfter, int x, int y, int cx, int cy, int uFlags);




    [DllImport("user32.dll")]


    [return: MarshalAs(UnmanagedType.Bool)]


    private static extern bool SetWindowPos(System.IntPtr hWnd, System.IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);




    [DllImport("user32.dll", EntryPoint = "SetWindowLongA")]


       static extern int SetWindowLong(int hwnd, int nIndex, long dwNewLong);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongA")]


    static extern long GetWindowLong(int hwnd, int nIndex);



    #endregion








    // Use this for initialization

    int handle;
    int fWidth, fHeight;

    void Start() {
        handle = GetActiveWindow();

        // fWidth = Screen.width;
        // fHeight = Screen.height;
        fWidth = 1920;
        fHeight = 1080;

        //Remove title bar


             long lCurStyle = GetWindowLong(handle, -16);  // GWL_STYLE=-16
        
        
             int a = 12582912;  //WS_CAPTION = 0x00C00000L
        
        
             int b = 1048576;  //WS_HSCROLL = 0x00100000L
        
        
             int c = 2097152;  //WS_VSCROLL = 0x00200000L
        
        
             int d = 524288;  //WS_SYSMENU = 0x00080000L
        
        
             int e = 16777216;  //WS_MAXIMIZE = 0x01000000L
        
        
        
        
        
        lCurStyle &= ~(a | b | c | d);
        
        
        lCurStyle &= e;
        
        
        SetWindowLong(handle, -16, lCurStyle);// GWL_STYLE=-16
        SetWindowPos(handle, 0, 0, 0, fWidth, fHeight, 32 | 64);

        // AssignTopmostWindow(CONSTANT_WINDOW_TITLE_FROM_GAME, true);
        AssignTopmostWindow("map", true);

    }


    void Update()
    {
        int getNowAct = GetActiveWindow();
        if( getNowAct != handle)
        {
            //Remove title bar


            long lCurStyle = GetWindowLong(handle, -16);  // GWL_STYLE=-16

            int a = 12582912;  //WS_CAPTION = 0x00C00000L
            int b = 1048576;  //WS_HSCROLL = 0x00100000L
            int c = 2097152;  //WS_VSCROLL = 0x00200000L
            int d = 524288;  //WS_SYSMENU = 0x00080000L
            int e = 16777216;  //WS_MAXIMIZE = 0x01000000L



            lCurStyle &= ~(a | b | c | d);

            lCurStyle &= e;

            SetWindowLong(handle, -16, lCurStyle);// GWL_STYLE=-16
            SetWindowPos(handle, 0, 0, 0, fWidth, fHeight, 32 | 64);
            // ShowWindowAsync(handle, 3);
        }
    }
 


    public bool AssignTopmostWindow(string WindowTitle, bool MakeTopmost) {


        UnityEngine.Debug.Log("Assigning top most flag to window of title: " + WindowTitle);


 


        System.IntPtr hWnd = FindWindow((string)null, WindowTitle);


 


        RECT rect = new RECT();


        GetWindowRect(new HandleRef(this, hWnd), out rect);


 


        return SetWindowPos(hWnd, MakeTopmost ? HWND_TOPMOST : HWND_NOT_TOPMOST, rect.X, rect.Y, rect.Width, rect.Height, SWP_SHOWWINDOW);


    }


 


    private string[] GetWindowTitles() {


        List<string> WindowList = new List<string>();


 


        Process[] ProcessArray = Process.GetProcesses();


        foreach (Process p in ProcessArray) {


            if (!IsNullOrWhitespace(p.MainWindowTitle)) {


                WindowList.Add(p.MainWindowTitle);


            }


        }


 


        return WindowList.ToArray();


    }


 


    public bool IsNullOrWhitespace(string Str) {


        if (Str.Equals("null")) {


            return true;


        }


        foreach (char c in Str) {


            if (c != ' ') {


                return false;


            }


        }


        return true;


    }


}


#endif
    