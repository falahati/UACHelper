using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UACHelper.Native.Methods;

namespace UACHelper
{
    /// <summary>
    ///     Contains multiple methods to add the UAC shield icon to the buttons, forms and native dialogs
    /// </summary>
    public static class WinForm
    {
        /// <summary>
        ///     Goes through the controls in the <see cref="Form" /> and adds the UAC shield icon to the desired
        ///     <see cref="Button" />. Then calls the Form.ShowDialog to display the form.
        /// </summary>
        /// <param name="uacButton">A <see cref="DialogResult" /> value to identify the button</param>
        /// <param name="form">Form to search in</param>
        /// <returns>A <see cref="DialogResult" /> value indicating the user selected action</returns>
        public static DialogResult ShowDialog(this Form form, DialogResult uacButton)
        {
            return ShowDialog(form, uacButton, null);
        }

        /// <summary>
        ///     Goes through the controls in the <see cref="Form" /> and adds the UAC shield icon to the desired
        ///     <see cref="Button" />. Then calls the Form.ShowDialog to display the form.
        /// </summary>
        /// <param name="uacButton">A <see cref="DialogResult" /> value to identify the button</param>
        /// <param name="form">Form to search in</param>
        /// <param name="owner">Owner window</param>
        /// <returns>A <see cref="DialogResult" /> value indicating the user selected action</returns>
        public static DialogResult ShowDialog(this Form form, DialogResult uacButton, IWin32Window owner)
        {
            return ShieldifyForm(uacButton, form, owner);
        }

        /// <summary>
        ///     Goes through the controls in the <see cref="Form" /> and adds the UAC shield icon to the desired
        ///     <see cref="Button" />. Then calls the Form.ShowDialog to display the form.
        /// </summary>
        /// <param name="button">A <see cref="DialogResult" /> value to identify the button</param>
        /// <param name="form">Form to search in</param>
        /// <param name="owner">Owner window</param>
        /// <returns>A <see cref="DialogResult" /> value indicating the user selected action</returns>
        public static DialogResult ShieldifyForm(DialogResult button, Form form, IWin32Window owner = null)
        {
            var loadHandler = new EventHandler((sender, args) =>
            {
                ShieldifyButton(
                    GetAllControls(sender as Form, control => control is Button)
                        .Cast<Button>()
                        .FirstOrDefault(c => c.DialogResult == button));
            });
            form.Load += loadHandler;
            var result = owner != null ? form.ShowDialog(owner) : form.ShowDialog();
            form.Load -= loadHandler;
            return result;
        }

        /// <summary>
        ///     Goes through the controls in the native dialog and adds the UAC shield icon to the desired native button.
        /// </summary>
        /// <param name="button">A <see cref="DialogResult" /> value to identify the button</param>
        /// <param name="dialogShowCode">The code responsible for showing the dialog</param>
        /// <returns>A <see cref="DialogResult" /> value indicating the user selected action</returns>
        public static DialogResult ShieldifyNativeDialog(DialogResult button, Func<DialogResult> dialogShowCode)
        {
            var callingThreadId = Kernel.GetCurrentThreadId();
            var thread = new Thread(() =>
            {
                try
                {
                    var found = false;
                    while (!found)
                    {
                        Thread.Sleep(100);
                        User.EnumThreadWindows(callingThreadId, (wnd, param) =>
                        {
                            var buffer = new StringBuilder(256);
                            User.GetClassName(wnd, buffer, buffer.Capacity);
                            if (buffer.ToString() == @"#32770")
                            {
                                ShieldifyNativeDialog(button, wnd);
                                found = true;
                                return false;
                            }
                            return true;
                        }, IntPtr.Zero);
                    }
                }
                catch
                {
                    // ignored
                }
            });
            thread.Start();
            var result = dialogShowCode();
            thread.Abort();
            return result;
        }

        
        /// <summary>
        ///     Changes the <see cref="Button" /> style to 'System' and adds the UAC shield icon
        /// </summary>
        /// <param name="control">The <see cref="Button" /> to add the icon to</param>
        public static void ShieldifyButton(this Button control)
        {
            control.FlatStyle = FlatStyle.System;
            ShieldifyNativeButton(control.Handle);
        }

        /// <summary>
        ///     Adds the UAC shield icon to the button
        /// </summary>
        /// <param name="buttonHandle">Handle of the <see cref="Button" /> to add the icon to</param>
        public static void ShieldifyNativeButton(IntPtr buttonHandle)
        {
            // BCM_SETSHIELD
            User.SendMessage(buttonHandle, 0x160C, 0, 0xFFFFFFFF);
        }

        /// <summary>
        ///     Goes through the controls in the native dialog and adds the UAC shield icon to the desired native button.
        /// </summary>
        /// <param name="button">A <see cref="DialogResult" /> value to identify the button</param>
        /// <param name="windowHandle">Handle of the dialog</param>
        /// <returns>Returns a <see cref="Boolean" /> value indicating the success of the process</returns>
        public static bool ShieldifyNativeDialog(DialogResult button, IntPtr windowHandle)
        {
            var numberOfButtons = 0;
            var numberOfItems = 0;
            var notFound = User.EnumChildWindows(windowHandle, (wnd, param) =>
            {
                var buffer = new StringBuilder(256);
                User.GetClassName(wnd, buffer, buffer.Capacity);
                numberOfItems++;
                if (buffer.ToString().ToLower().Contains(@"button"))
                {
                    numberOfButtons++;
                    if (User.GetDialogControlId(wnd) == (int)button)
                    {
                        ShieldifyNativeButton(wnd);
                        return false;
                    }
                }
                else
                {
                    if (ShieldifyNativeDialog(button, wnd))
                    {
                        return false;
                    }
                }
                return true;
            }, IntPtr.Zero);
            if (notFound && numberOfButtons == 1 && button == DialogResult.OK)
            {
                ShieldifyNativeDialog(DialogResult.Cancel, windowHandle);
            }
            return !notFound && numberOfItems > 0;
        }

        private static List<Control> GetAllControls(Control control, Func<Control, bool> checkFunc)
        {
            var controls = new List<Control>();
            foreach (Control c in control.Controls)
            {
                if (checkFunc(c))
                {
                    controls.Add(c);
                }
                controls.AddRange(GetAllControls(c, checkFunc));
            }
            return controls;
        }
    }
}