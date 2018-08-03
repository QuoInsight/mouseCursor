
  // [ https://stackoverflow.com/questions/457069/get-current-mouse-cursor-type ]
  // powershell.exe -noprofile -command "Add-Type -ReferencedAssemblies System.Windows.Forms -Path \"waitCursor.cs\"; [myMainClass]::waitCursor(60)"
  // [Invoke Power Shell] "powershell.exe"
  //   "-noprofile" ""
  //   "-command" "Add-Type -ReferencedAssemblies System.Windows.Forms -Path """ + Environment.CurrentDirectory.Replace("\","\\") + "\\waitCursor.cs"" ; [myMainClass]::waitCursor(" + timeOut.ToString() + ") "
  // cmd.exe "/c" "powershell.exe -noprofile -command ""Add-Type -ReferencedAssemblies System.Windows.Forms -Path """ + Environment.CurrentDirectory.Replace("\","\\") + "\\waitCursor.cs"" ; [myMainClass]::waitCursor(" + timeOut.ToString() + ") "

  using System;
  using System.Runtime.InteropServices;
  using System.Windows.Forms;
  using System.Threading;

  public class myMainClass {

    public static string waitCursor(int timeOut=60) {
      int elapse=0;  string cursorType = "";  CURSORINFO pci;
      do {
        elapse++;  if (elapse > 1) System.Threading.Thread.Sleep(200);
        pci = new CURSORINFO();  pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO)); 
        GetCursorInfo(ref pci);  cursorType = (pci.hCursor==System.Windows.Forms.Cursors.WaitCursor.Handle)
            ? "WaitCursor" : "cursorHandle: " + pci.hCursor.ToString();
      } while ( cursorType=="WaitCursor" && elapse<timeOut );
      return cursorType;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct POINT {
      public System.Int32 x;
      public System.Int32 y;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct CURSORINFO {
      public System.Int32 cbSize;  // The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
      public System.Int32 flags;
      public System.IntPtr hCursor; 
      public POINT ptScreenPos;
    }

    [DllImport("user32.dll")]
    static extern bool GetCursorInfo(ref CURSORINFO pci);

  }
