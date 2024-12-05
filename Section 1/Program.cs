using System;
using System.Windows.Forms;

namespace Section1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure the application for single-threaded apartment (STA) mode.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Start the application with the main form.
                Application.Run(new BaseForm());
            }
            catch (Exception ex)
            {
                // Log the error and show a user-friendly message.
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Add logging here if required, e.g., write to a log file or an error reporting service.
            }
        }
    }
}