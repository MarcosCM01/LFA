using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proyecto_LFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            if (examinar.ShowDialog() == DialogResult.OK)// si el archivo es correctamente encontrado
            {
                txbRuta.Text = examinar.FileName;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static string expresionR_SETS = "( *.L+. *.=. *.('.S.'|C.H.R.\\(.N+.\\)).((\\..\\.|\\+).('.S.'|C.H.R.\\(.N+.\\)))*)";
        public static string expresionR_TOKENS = " *TOKEN +N+ *= *(('?S'?|L+) *)+";
        public static string expresionR_ACTIONS = " *N+ *= *'L+'";
        public static string expresionR_ERROR = " *ERROR *= *N+";
        public static List<char> operadores = new List<char>();
        public static List<char> st_SETS = new List<char>();
        public static List<char> st_TOKENS = new List<char>();
        public static List<char> st_ACTIONS = new List<char>();
        public static List<char> st_ERROR = new List<char>();

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (txbRuta.Text != "")// si no hay ruta del archivo
            {
                if (Helpers.ArchivoVacio(txbRuta.Text) != false) //el archivo no esta vacio
                {
                    //GENERAR LISTA DE OPERADORES 
                    Expresiones_Regulares.LlenarOP(operadores);

                    //GENERACION DE LISTAS ST
                    Expresiones_Regulares.Generar_ST(operadores, st_SETS, expresionR_SETS);
                    //Expresiones_Regulares.Generar_ST(operadores, st_TOKENS, expresionR_TOKENS);
                    //Expresiones_Regulares.Generar_ST(operadores, st_ACTIONS, expresionR_ACTIONS);
                    //Expresiones_Regulares.Generar_ST(operadores, st_ERROR, expresionR_ERROR);

                    //GENERAR DICCIONARIO SOBRE VALORES DE PRECEDENCIA
                    Arbol_Expresiones.LlenarDiccionarioPrecedencia(operadores);

                    //GENERACION DE ARBOLES DE EXPRESION
                    //PARA SETS
                    Arbol_Expresiones.GenerarArbol(st_SETS, operadores, expresionR_SETS);

                    Prueba.LeerArchivo(txbRuta.Text);//LOGICA PARA LECTURA DEL ARCHIVO
                }
                else
                {
                    MessageBox.Show("Archivo Vacio");
                }
            }
            else
            {
                MessageBox.Show("Por favor, primero seleccione un archivo");
            }
            
            //El archivo no tiene nada
        }
    }
}
