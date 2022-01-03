using System;
using System.IO;
using System.Windows.Forms;

namespace ASF_Manager
{
    static class Program
    {
        public static string Config_FilePath = Path.Combine(Directory.GetCurrentDirectory(), "cfg.json");
        /// <summary>
        /// Ponto de entrada Main para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
