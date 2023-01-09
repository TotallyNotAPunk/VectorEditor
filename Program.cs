using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorEditor
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Panel panel1 = new Panel();
            GraphSystem gs = new GraphSystem(panel1.CreateGraphics());
            Model model = new Model(gs);
            Application.Run(new Form1(model));
        }
    }
}
