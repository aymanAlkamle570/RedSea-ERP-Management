namespace RedSea_ERP_Management
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (Properties.Settings.Default.FirstTime)
            {
                Application.Run(new Wizard());
            }
            else
            {
Application.Run(new Form1());
            }
        }
    }
}