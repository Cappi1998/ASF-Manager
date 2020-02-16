using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ASF_Manager
{
    class Log
    {
        Main MyForm1 = new Main();

        public static void global_void_Log(string msg, Color color)
        {
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.SelectionColor = color));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.AppendText(msg + Environment.NewLine)));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.SelectionColor = Main._Main.txtConsole.ForeColor));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.SelectionStart = Main._Main.txtConsole.Text.Length));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.ScrollToCaret()));

            File.AppendAllText("log.txt", msg + "\n");

        }

        public static void info(string msg)
        {
            msg = DateTime.Now + " - " + msg;
            global_void_Log(msg, Color.LimeGreen);
        }

        public static void info(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            info(msg);
        }

        public static void orange(string msg)
        {

            msg = DateTime.Now + " - " + msg;
            global_void_Log(msg, Color.DarkOrange);
        }

        public static void orange(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            orange(msg);
        }

        public static void blue(string msg)
        {

            msg = DateTime.Now + " - " + msg;
            global_void_Log(msg, Color.BlueViolet);
        }

        public static void blue(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            blue(msg);
        }

        public static void pink(string msg)
        {
            msg = DateTime.Now + " - " + msg;
            global_void_Log(msg, Color.DeepPink);
        }

        public static void pink(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            pink(msg);
        }

        public static void error(string msg)
        {
            msg = DateTime.Now + " - " + msg;
            global_void_Log(msg, Color.DarkRed);
        }

        public static void error(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            error(msg);
        }

        public static void error(string msg, Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            msg = DateTime.Now + " - " + msg + ". " + e.Message;

            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.SelectionColor = Color.DarkRed));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.AppendText(msg + Environment.NewLine)));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.SelectionColor = Main._Main.txtConsole.ForeColor));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.SelectionStart = Main._Main.txtConsole.Text.Length));
            Main._Main.txtConsole.Invoke(new Action(() => Main._Main.txtConsole.ScrollToCaret()));

            File.AppendAllText("log.txt", msg + "\n");
            File.AppendAllText("error.txt", msg + "\n" + e.StackTrace + "\n");




        }

    }
}
