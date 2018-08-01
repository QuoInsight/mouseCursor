// [Ref] https://stackoverflow.com/questions/457069/get-current-mouse-cursor-type

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace myNameSpace {
  class myClass {

    private static bool IsWaitCursor() {
      var h = Cursors.WaitCursor.Handle;

      CURSORINFO pci;
      pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
      GetCursorInfo(out pci);

      return pci.hCursor == h;
    }

    private static string getCursorType() {
      var cursorType = "";

      CURSORINFO pci = new CURSORINFO();
      pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
      GetCursorInfo(ref pci);

      if (pci.hCursor == Cursors.Default.Handle) {
        cursorType = "Default";
      } else if (pci.hCursor == Cursors.AppStarting.Handle) {
        cursorType = "AppStarting";
      } else if (pci.hCursor == Cursors.Arrow.Handle) {
        cursorType = "Arrow";
      } else if (pci.hCursor == Cursors.Cross.Handle) {
        cursorType = "Cross";
      } else if (pci.hCursor == Cursors.Hand.Handle) {
        cursorType = "Hand";
      } else if (pci.hCursor == Cursors.Help.Handle) {
        cursorType = "Help";
      } else if (pci.hCursor == Cursors.HSplit.Handle) {
        cursorType = "HSplit";
      } else if (pci.hCursor == Cursors.IBeam.Handle) {
        cursorType = "IBeam";
      } else if (pci.hCursor == Cursors.No.Handle) {
        cursorType = "No";
      } else if (pci.hCursor == Cursors.NoMove2D.Handle) {
        cursorType = "NoMove2D";
      } else if (pci.hCursor == Cursors.NoMoveHoriz.Handle) {
        cursorType = "NoMoveHoriz";
      } else if (pci.hCursor == Cursors.NoMoveVert.Handle) {
        cursorType = "NoMoveVert";
      } else if (pci.hCursor == Cursors.PanEast.Handle) {
        cursorType = "PanEast";
      } else if (pci.hCursor == Cursors.PanNE.Handle) {
        cursorType = "PanNE";
      } else if (pci.hCursor == Cursors.PanNorth.Handle) {
        cursorType = "PanNorth";
      } else if (pci.hCursor == Cursors.PanNW.Handle) {
        cursorType = "PanNW";
      } else if (pci.hCursor == Cursors.PanSE.Handle) {
        cursorType = "PanSE";
      } else if (pci.hCursor == Cursors.PanSouth.Handle) {
        cursorType = "PanSouth";
      } else if (pci.hCursor == Cursors.PanSW.Handle) {
        cursorType = "PanSW";
      } else if (pci.hCursor == Cursors.PanWest.Handle) {
        cursorType = "PanWest";
      } else if (pci.hCursor == Cursors.SizeAll.Handle) {
        cursorType = "SizeAll";
      } else if (pci.hCursor == Cursors.SizeNESW.Handle) {
        cursorType = "SizeNESW";
      } else if (pci.hCursor == Cursors.SizeNS.Handle) {
        cursorType = "SizeNS";
      } else if (pci.hCursor == Cursors.SizeNWSE.Handle) {
        cursorType = "SizeNWSE";
      } else if (pci.hCursor == Cursors.SizeWE.Handle) {
        cursorType = "SizeWE";
      } else if (pci.hCursor == Cursors.UpArrow.Handle) {
        cursorType = "UpArrow";
      } else if (pci.hCursor == Cursors.VSplit.Handle) {
        cursorType = "VSplit";
      } else if (pci.hCursor == Cursors.WaitCursor.Handle) {
        cursorType = "WaitCursor";
      } else {
        cursorType = "#" + pci.hCursor.ToString();
      }

      return cursorType;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct POINT {
      public Int32 x;
      public Int32 y;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct CURSORINFO {
      public Int32 cbSize;        // Specifies the size, in bytes, of the structure. 
      // The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
      public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
      //    0             The cursor is hidden.
      //    CURSOR_SHOWING    The cursor is showing.
      public IntPtr hCursor;          // Handle to the cursor. 
      public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor. 
    }

    [DllImport("user32.dll")]
    static extern bool GetCursorInfo(ref CURSORINFO pci);

    static void Main(string[] args) {

      // Console.WriteLine( IsWaitCursor() );
      Console.WriteLine( getCursorType() );

    }

  }
}
