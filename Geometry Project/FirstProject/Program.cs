using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Dot A = new Dot(9, 4, 1);
            Dot B = new Dot(2, 6, 8);
            Dot C = new Dot(1, 1, 1);

            Cube c = new Cube(A, B, C);
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Drawer());
        }
    }
}
