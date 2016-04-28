using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using UACHelper.Sample.Properties;

namespace UACHelper.Sample
{
    internal partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            Helper.SetLabelText(lbl_behavior,
                () => UACHelper.GetExpectedRunlevel(Assembly.GetExecutingAssembly().Location).ToString());

            Helper.SetLabelText(lbl_username, () => WindowsIdentity.GetCurrent()?.Name ?? "SYSTEM");

            Helper.SetLabelText(lbl_sessionOwner, () => UACHelper.DesktopOwner.ToString());

            Helper.SetLabelText(lbl_sameUser, () => UACHelper.IsDesktopOwner.ToString());

            Helper.SetLabelText(lbl_isAdministrator, () => UACHelper.IsAdministrator.ToString());

            Helper.SetLabelText(lbl_isElevated, () => UACHelper.IsElevated.ToString());

            Helper.SetLabelText(lbl_uacEnable, () => UACHelper.IsUACEnable.ToString());

            Helper.SetLabelText(lbl_uacSupported, () => UACHelper.IsUACSupported.ToString());

            btn_disable.Enabled = UACHelper.IsElevated && UACHelper.IsUACSupported && AAMSettings.IsEnable;
            btn_enable.Enabled = UACHelper.IsElevated && UACHelper.IsUACSupported && !AAMSettings.IsEnable;

            btn_restartNormal.Enabled = UACHelper.IsElevated;
            btn_restartElevated.Enabled = !UACHelper.IsElevated;

            btn_restartElevated.ShieldifyButton();

            if (UACHelper.IsElevated && UACHelper.IsUACSupported)
            {
                ProcessRefresh();
            }
            else
            {
                gb_processes.Enabled = false;
            }

            if (!UACHelper.IsElevated || !UACHelper.IsUACEnable)
            {
                gb_uacNotifications.Enabled = false;
            }
            NotificationsRefresh();
        }

        private void ProcessRefresh(object sender = null, EventArgs e = null)
        {
            lb_processes.Items.Clear();
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    if (UACHelper.IsProcessElevated(process))
                    {
                        lb_processes.Items.Add($"[{process.Id.ToString("D5")}] {process.ProcessName}");
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void NotificationsRefresh(object sender = null, EventArgs e = null)
        {
            cb_forceSecureScreen.CheckedChanged -= NotificationsRefresh;
            cb_userConsent.CheckedChanged -= NotificationsRefresh;
            tb_uacLevel.ValueChanged -= NotificationsRefresh;

            if (sender != null)
            {
                AAMSettings.UserPromptBehavior = cb_userConsent.Checked
                    ? UserPromptType.Prompt
                    : UserPromptType.RejectAll;
                AAMSettings.ForceDimPromptScreen = cb_forceSecureScreen.Checked;

                switch (tb_uacLevel.Value)
                {
                    case 0:
                        AAMSettings.AdminPromptBehavior = AdminPromptType.AllowAll;
                        break;
                    case 1:
                        AAMSettings.AdminPromptBehavior = AdminPromptType.Prompt;
                        break;
                    case 2:
                        AAMSettings.AdminPromptBehavior = AdminPromptType.PromptWithPasswordConfirmation;
                        break;
                    case 4:
                        AAMSettings.AdminPromptBehavior = AdminPromptType.DimmedPrompt;
                        break;
                    case 5:
                        AAMSettings.AdminPromptBehavior = AdminPromptType.DimmedPromptWithPasswordConfirmation;
                        break;
                    default:
                        AAMSettings.AdminPromptBehavior = AdminPromptType.DimmedPromptForNonWindowsBinaries;
                        break;
                }
            }


            switch (AAMSettings.AdminPromptBehavior)
            {
                case AdminPromptType.AllowAll:
                    tb_uacLevel.Value = 0;
                    break;
                case AdminPromptType.Prompt:
                    tb_uacLevel.Value = 1;
                    break;
                case AdminPromptType.PromptWithPasswordConfirmation:
                    tb_uacLevel.Value = 2;
                    break;
                case AdminPromptType.DimmedPrompt:
                    tb_uacLevel.Value = 4;
                    break;
                case AdminPromptType.DimmedPromptWithPasswordConfirmation:
                    tb_uacLevel.Value = 5;
                    break;
                default:
                    tb_uacLevel.Value = 3;
                    break;
            }

            lbl_1.Enabled = lbl_2.Enabled = !AAMSettings.ForceDimPromptScreen;

            cb_forceSecureScreen.Checked = AAMSettings.ForceDimPromptScreen;
            cb_userConsent.Checked = AAMSettings.UserPromptBehavior == UserPromptType.Prompt;

            cb_forceSecureScreen.CheckedChanged += NotificationsRefresh;
            cb_userConsent.CheckedChanged += NotificationsRefresh;
            tb_uacLevel.ValueChanged += NotificationsRefresh;
        }

        private void DisableUAC(object sender, EventArgs e)
        {
            if (Helper.ExecuteAndReport(() => AAMSettings.IsEnable = false) &&
                MessageBox.Show(Resources.MainForm_Restart_Message, Resources.MainForm_Restart_Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Process.Start(@"shutdown.exe", @"-r -t 0");
            }
        }

        private void EnableUAC(object sender, EventArgs e)
        {
            if (Helper.ExecuteAndReport(() => AAMSettings.IsEnable = true) &&
                MessageBox.Show(Resources.MainForm_Restart_Message, Resources.MainForm_Restart_Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Process.Start(@"shutdown.exe", @"-r -t 0");
            }
        }

        private void RestartElevated(object sender, EventArgs e)
        {
            if (
                Helper.ExecuteAndReport(
                    () => UACHelper.StartElevated(new ProcessStartInfo(Assembly.GetExecutingAssembly().Location))))
            {
                Application.Exit();
            }
        }

        private void ShowGoodies(object sender, EventArgs e)
        {
            DialogResult result;
            if (sender == btn_colorBox)
            {
                result = WinForm.ShieldifyNativeDialog(DialogResult.OK, () => new ColorDialog().ShowDialog());
            }
            else if (sender == btn_saveFileDialog)
            {
                result = WinForm.ShieldifyNativeDialog(DialogResult.OK, () => new SaveFileDialog().ShowDialog());
            }
            else if (sender == btn_openFileDialog)
            {
                result = WinForm.ShieldifyNativeDialog(DialogResult.OK, () => new OpenFileDialog().ShowDialog());
            }
            else if (sender == btn_folderDialog)
            {
                result = WinForm.ShieldifyNativeDialog(DialogResult.OK, () => new FolderBrowserDialog().ShowDialog());
            }
            else if (sender == btn_fontDialog)
            {
                result = WinForm.ShieldifyNativeDialog(DialogResult.OK, () => new FontDialog().ShowDialog());
            }
            else if (sender == btn_customDialog)
            {
                result = new CustomDialog().ShowDialog(DialogResult.No);
            }
            else
            {
                result = WinForm.ShieldifyNativeDialog(DialogResult.Yes,
                    () =>
                        MessageBox.Show(this, Resources.MainForm_ShowGoodies_MessageBox_Message,
                            Resources.MainForm_ShowGoodies_MessageBox_Caption, MessageBoxButtons.YesNoCancel,
                            MessageBoxIcon.Question));
            }
            MessageBox.Show(string.Format(Resources.MainForm_ShowGoodies_Result_Message, result),
                Resources.MainForm_ShowGoodies_Result_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void RestartNormal(object sender, EventArgs e)
        {
            if (
                Helper.ExecuteAndReport(
                    () => UACHelper.StartLimited(new ProcessStartInfo(Assembly.GetExecutingAssembly().Location))))
            {
                Application.Exit();
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}