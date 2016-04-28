using System;
using System.Windows.Forms;

namespace UACHelper.Sample
{
    internal static class Helper
    {
        public static bool ExecuteAndReport(Action job)
        {
            try
            {
                job();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static void SetLabelText(Label label, Func<string> value)
        {
            try
            {
                label.Text = value();
            }
            catch (Exception e)
            {
                label.Text = e.GetType().Name;
            }
        }
    }
}