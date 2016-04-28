# UAC Helper Class Library
A helper class library to detect, manage and use UAC functionalities in your program

## WHERE TO FIND
This library is available as a NuGet package at [nuget.org](https://www.nuget.org/packages/UACHelper/).

## HOW TO USE
Currently there are three main classes in this library:

### `UACHelper.UACHelper`
This static class contains properties about the current state of the application as well as providing methods to get information about other processes and starting new ones.

##### [Static Read Only Properties]
* `UACHelper.IsElevated`:  A `Boolean` value indicating if the current process has full administrative rights
* `UACHelper.IsUACSupported`: A `Boolean` value indicating if UAC virtualization is supported on the current machine
* `UACHelper.IsDesktopOwner`: A `Boolean` value indicating if the user that owns this process also owns the desktop session
* `UACHelper.IsVirtualized`: A `Boolean` value indicating if the current process started under UAC virtualization
* `UACHelper.IsAdministrator`: A `Boolean` value indicating if the user that owns this process is a member of the 'Administrators' group
* `UACHelper.IsUACEnable`: A `Boolean` value indicating if the UAC vitalization is enable on this machine
* `UACHelper.DesktopOwner`: Returns a `NTAccount` object containing information about the current desktop owner
* `UACHelper.Owner`: Returns a `WindowsIdentity` object containing information about the current process owner

##### [Static Methods]
* `UACHelper.GetProcessDesktopOwner()`: Returns a `NTAccount` object containing information about the desktop owner of a specific `Process`
* `UACHelper.GetProcessOwner()`: Returns a `WindowsIdentity` object containing information about the owner of a specific `Process`
* `UACHelper.IsProcessElevated()`: Indicates if the passed `Process` started with elevated privileges
* `UACHelper.GetExpectedRunlevel()`: Checks a file and retrieve the expected `RunLevel` for it to start
* `UACHelper.StartElevated()`: Starts a new elevated `Process` with the start info provided
* `UACHelper.StartLimited()`: Starts a new `Process` with the start info provided and with the limited access rights
* `UACHelper.StartWithShell()`: Starts a new `Process` with the start info provided and with the same rights as the current active shell process
* `UACHelper.StartAndCopyProcessPermission()`: Starts a new `Process` with the start info provided and with the same rights as the mentioned `Process`


### `UACHelper.AAMSettings`
This static class contains settings of the "Admin Approval Mode"

##### [Static Properties]
* `AAMSettings.IsEnable`: Enables the "administrator in Admin Approval Mode" user type while also enabling all other User Account Control (UAC) policies. Requires restart.
* `AAMSettings.EnforceAdminCodeSignatures`: Enforce cryptographic signatures on any interactive application that requests elevation of privilege.
* `AAMSettings.ForceDimPromptScreen`: Will force all UAC prompts to happen on the user's secure desktop.
* `AAMSettings.IsVirtualizationEnable`: Enables the redirection of legacy application File and Registry writes that would normally fail as standard user to a user-writable data location.
* `AAMSettings.IsInstallerDetectionEnable`: Used to heuristically detect applications that require an elevation of privilege to install.
* `AAMSettings.UserPromptBehavior`:  AAM behaviors regarding users running elevated applications
* `AAMSettings.AdminPromptBehavior`: AAM behaviors regarding administrators' changes to system


### `UACHelper.WinForm`
This static class contains multiple methods to add the UAC shield icon to the buttons, forms and native dialogs

##### [Static Methods]
* `WinForm.ShieldifyNativeDialog`: Goes through the controls in the native dialog and adds the UAC shield icon to the desired native button.
* `WinForm.ShieldifyNativeButton`: Adds the UAC shield icon to the button
* `WinForm.ShieldifyForm`: Goes through the controls in the `Form` and adds the UAC shield icon to the desired `Button`. Then calls the `Form.ShowDialog` to display the form.
* `WinForm.ShieldifyButton`: Changes the `Button.FlatStyle` to `FlatStyle.System` and adds the UAC shield icon

##### [Extension Methods]
* `Form.ShowDialog`: Alias of `WinForm.ShieldifyForm`
* `Form.ShieldifyButton`: Alias of `WinForm.ShieldifyButton`

## EXAMPLES
Check the 'UACHelper.Sample' for tons of examples on how to use the library.
![Screenshot](/screenshot.jpg?raw=true "Screenshot")

* Restart the current program in Elevated Mode:
```C#
UACHelper.StartElevated(
    new ProcessStartInfo(Assembly.GetExecutingAssembly().Location));
```

* Restart the current program in Limited Mode:
```C#
UACHelper.StartLimited(
    new ProcessStartInfo(Assembly.GetExecutingAssembly().Location));
```

## TO-DO
* Create an elevated Out-Of-Process COM object from a limited process - Read More: [The COM Elevation Moniker](https://msdn.microsoft.com/en-us/ms679687.aspx)
* Using `IShellDispatch2.ShellExecute()` to start a process with current shell privileges - Read More: [Execute In Explorer Sample](https://msdn.microsoft.com/library/dd940355)

## LICENSE
The MIT License (MIT)

Copyright (c) 2016 Soroush

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
