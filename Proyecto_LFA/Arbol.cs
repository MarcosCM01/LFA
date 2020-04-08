using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_LFA
{
    public class Arbol
    {
        public  PictureBox ptb { get; set; }        
        public  Bitmap bit;
        public  Graphics g;
        public  Pen lapiz;
        public  int despX = 50;
        public  int despY = 30;
        public  int raizX;
        public  int raizY;

        public Arbol(PictureBox ptb) 
        {
            this.ptb = ptb;
            lapiz = new Pen(Color.Red,5);
            bit = new Bitmap(ptb.Width, ptb.Height);
            raizX = (ptb.Width *3)/4;
            raizY = 20;
        }

        public void DibujarArbol(Nodo_Generico nodo, int rama)
        {
            if (nodo != null)
            {
                ptb.Image = (Image)bit;
                g = Graphics.FromImage(bit);
                if (rama == 0)
                {
                    nodo.posX = raizX;
                    nodo.posY = raizY;
                    g.DrawString(nodo.id, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Red), nodo.posX, nodo.posY);
                    g.DrawEllipse(new Pen(Color.Black, 1), nodo.posX - 5, nodo.posY, 15, 15);
                }
                else if (rama == 1)
                {
                    nodo.posX = nodo.padre.posX - despX;
                    nodo.posY = nodo.padre.posY + despY;
                    g.DrawString(nodo.id, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Black), nodo.posX, nodo.posY);
                    g.DrawEllipse(new Pen(Color.Black, 1), nodo.posX - 5, nodo.posY, 15, 15);
                    g.DrawLine(new Pen(Color.Black, 2), nodo.padre.posX, nodo.padre.posY, nodo.posX, nodo.posY);

                }
                else if (rama == 2)
                {

                    nodo.posX = nodo.padre.posX + despX;
                    nodo.posY = nodo.padre.posY + despY;
                    g.DrawString(nodo.id, new Font("Microsoft Sans Serif", 8, FontStyle.Regular), new SolidBrush(Color.Black), nodo.posX, nodo.posY);
                    g.DrawEllipse(new Pen(Color.Black, 1), nodo.posX + 5, nodo.posY, 15, 15);
                    g.DrawLine(new Pen(Color.Black, 2), nodo.padre.posX, nodo.padre.posY, nodo.posX, nodo.posY);

                }
                if (despX >=60)
                {
                    despX -= 20;
                }
                DibujarArbol(nodo.hijo_izquierdo, 1);
                DibujarArbol(nodo.hijo_derecho, 2);
            }
        }
    }
}
