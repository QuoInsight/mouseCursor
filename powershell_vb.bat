@rem cmd.exe "/c" "powershell.exe -noprofile -command ""Add-Type -ReferencedAssemblies System.Windows.Forms -Path """ + Environment.CurrentDirectory.Replace("\","\\") + "\\waitCursor.vb"" ; [myMainClass]::waitCursor(" + timeOut.ToString() + ") "
powershell.exe -noprofile -command "Add-Type -ReferencedAssemblies System.Windows.Forms -Path \"waitCursor.vb\"; [myMainClass]::waitCursor(60)"
