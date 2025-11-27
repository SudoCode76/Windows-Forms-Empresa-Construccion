using System;
using System.Windows.Forms;

namespace EmpresaConstruccion
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
            string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=76452510;Database=distribucion_materiales;";
            using (var login = new LoginForm(connectionString))
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string usuario = login.Controls["txtUsuario"].Text;
                    Application.Run(new DashboardForm(connectionString, usuario));
                }
            }
        }
    }
}