
  ' [ https://stackoverflow.com/questions/457069/get-current-mouse-cursor-type ]
  ' powershell.exe -noprofile -command "Add-Type -ReferencedAssemblies System.Windows.Forms -Path \"waitCursor.vb\"; [myMainClass]::waitCursor(60)"
  ' [Invoke Power Shell] "powershell.exe"
  '   "-noprofile" ""
  '   "-command" "Add-Type -ReferencedAssemblies System.Windows.Forms -Path """ + Environment.CurrentDirectory.Replace("\","\\") + "\\waitCursor.vb"" ; [myMainClass]::waitCursor(" + timeOut.ToString() + ") "
  ' cmd.exe "/c" "powershell.exe -noprofile -command ""Add-Type -ReferencedAssemblies System.Windows.Forms -Path """ + Environment.CurrentDirectory.Replace("\","\\") + "\\waitCursor.vb"" ; [myMainClass]::waitCursor(" + timeOut.ToString() + ") "

  Option Explicit

  Imports System
  Imports System.Runtime.InteropServices
  Imports System.Windows.Forms
  Imports System.Threading

  Public Class myMainClass

    Public Shared Function waitCursor(Optional timeOut As Integer=60) As String
      Dim elapse As Integer = 0
      Dim cursorType As String = ""
      Dim pci As CURSORINFO
      pci.cbSize = Marshal.SizeOf(GetType(CURSORINFO)) '' Len(pci)
      Do
        GetCursorInfo(pci)
        cursorType = "cursorHandle: " + pci.hCursor.ToString()
        if (pci.hCursor=System.Windows.Forms.Cursors.WaitCursor.Handle) then cursorType="WaitCursor"
        if (elapse > 0) then System.Threading.Thread.Sleep(1000)
        elapse = elapse + 1
      Loop While ( cursorType="WaitCursor" And elapse<timeOut )
      return cursorType
    End Function

    <StructLayout(LayoutKind.Sequential)>
    Structure POINT  '' Private Type POINT
      Public x As System.Int32
      Public y As System.Int32
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure CURSORINFO
      Public cbSize As System.Int32  ' The caller must set this to Marshal.SizeOf(typeof(CURSORINFO)).
      Public flags As System.Int32
      Public hCursor As System.IntPtr
      Public ptScreenPos As POINT
    End Structure

    Private Declare Function GetCursorInfo Lib "user32.dll" (ByRef pci As CURSORINFO) As Boolean

  End Class
