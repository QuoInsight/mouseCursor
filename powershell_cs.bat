@rem cmd.exe "/c powershell.exe -noprofile -command ""Add-Type -ReferencedAssemblies System.Windows.Forms -Path """ + Environment.CurrentDirectory.Replace("\","\\") + "\\waitCursor.cs"" ; [myClass]::waitCursor(" + timeOut.ToString() + ") "
powershell.exe -noprofile -command "Add-Type -ReferencedAssemblies System.Windows.Forms -Path \"B:\\waitCursor.cs\"; [myClass]::waitCursor(60)"
