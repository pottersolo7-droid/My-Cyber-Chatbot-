using CybersecurityBot;
using CybersecurityBotGUI;
using System;
using System.Windows.Forms;

namespace CybersecurityBotGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChatBotForm());
        }
    }
}