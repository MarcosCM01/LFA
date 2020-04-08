using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_LFA
{
    public partial class FormArbol : Form
    {
        public FormArbol()
        {
            InitializeComponent();
        }
        
        public static Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormArbol_Click(object sender, EventArgs e)
        {
            var arbol = new Arbol(pictureBox1);
            arbol.DibujarArbol(Form1.arbol_Sintactico, 0);
        }

    }
}
