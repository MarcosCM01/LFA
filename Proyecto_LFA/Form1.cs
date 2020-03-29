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
        //EXPRESIONES REGULARES
        //"( *.L+. *.=. *.(('.S.')|(C.H.R.\\(.N+.\\))).(((\\..\\.)|\\+).(('.S.')|(C.H.R.\\(.N+.\\))))*)"
        //"( *.T.O.K.E.N. *.N+. *.=. *.((('.S.')|S+). *)+)"
        public static string expresionR_SETS = "( *.L+. *.=. *.(('.S.')|(C.H.R.\\(.N+.\\))).(((\\..\\.)|\\+).(('.S.')|(C.H.R.\\(.N+.\\))). *)*)";
        public static string expresionR_TOKENS = "( *.T.O.K.E.N.Z*.N+.Z*.=.Z*.((('.S.')|L+). *)+)";
        public static string expresionR_ACTIONS = "( *.N+. *.=. *.'.L+.')";
        public static string expresionR_ERROR = "( *.E.R.R.O.R. *.=. *.N+)";
        public static string prueba = "((D.D*)|('.CHARSET.')|('.CHARSET.')|(=)|(<.>)|(<)|(>)|(>.=)|(<.=)|(\\+)|(-)|(O.R)|(\\*)|(A.N.D)|(M.O.D)|(D.I.V)|(N.O.T)|(\\(.\\*)|(\\*.\\))|(;)|(\\.)|({)|(})|(\\()|(\\))|([)|(])|(\\..\\.)|(:)|(,)|(:.=)|(L.(L|D)*).#)";
        //LISTAS PARA ALMACENAR LOS SIMBOLOS TERMINALES Y OPERADORES
        public static List<char> operadores = new List<char>();
        public static List<char> st_SETS = new List<char>();
        public static List<char> st_TOKENS = new List<char>();
        public static List<char> st_ACTIONS = new List<char>();
        public static List<char> st_ERROR = new List<char>();
        public static List<string> st_SINTACTICO = new List<string>();

        public static List<char> st_prueba = new List<char>();

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (txbRuta.Text != "")// si no hay ruta del archivo
            {
                if (Prueba.ArchivoVacio(txbRuta.Text) != false) //el archivo no esta vacio
                {
                    //GENERAR LISTA DE OPERADORES 
                    Expresiones_Regulares.LlenarOP(operadores);

                    //GENERACION DE LISTAS ST
                    Expresiones_Regulares.Generar_ST(operadores, st_SETS, expresionR_SETS);
                    Expresiones_Regulares.Generar_ST(operadores, st_TOKENS, expresionR_TOKENS);
                    Expresiones_Regulares.Generar_ST(operadores, st_ACTIONS, expresionR_ACTIONS);
                    Expresiones_Regulares.Generar_ST(operadores, st_ERROR, expresionR_ERROR);
                    Expresiones_Regulares.Generar_ST(operadores, st_prueba, prueba);

                    //GENERAR DICCIONARIO SOBRE VALORES DE PRECEDENCIA
                    Arbol_Expresiones.LlenarDiccionarioPrecedencia(operadores);
                    Helpers.LlenarDiccionarioPrecedencia(operadores);
                    //GENERACION DE ARBOLES DE EXPRESION
                    var arbol_SETS = Arbol_Expresiones.GenerarArbol(st_SETS, operadores, expresionR_SETS);
                    var arbol_TOKENS = Arbol_Expresiones.GenerarArbol(st_TOKENS, operadores, expresionR_TOKENS);
                    var arbol_ACTIONS = Arbol_Expresiones.GenerarArbol(st_ACTIONS, operadores, expresionR_ACTIONS);
                    var arbol_ERROR = Arbol_Expresiones.GenerarArbol(st_ERROR, operadores, expresionR_ERROR);
                    var arbol_prueba = Arbol_Expresiones.GenerarArbol(st_prueba, operadores, prueba);

                    var inicioTokens = 0;
                    var finalTokens = 0;

                    //ANALIZADOR LEXICO
                    Prueba.Analizador_Lexico(txbRuta.Text, arbol_SETS, arbol_TOKENS, arbol_ACTIONS, arbol_ERROR, ref inicioTokens, ref finalTokens);//LOGICA PARA LECTURA DEL ARCHIVO

                    if (MensajeError.error_Encontrado == false)
                    {
                        //ANALIZADOR SINTACTICO
                        //------------------------------> ANALIZADOR SINTACTICO
                        var error_Sintactico = false;
                        var expresion_TokensS = SintacticoA.Tokenizar(Prueba.gramatica, inicioTokens, finalTokens, ref error_Sintactico);
                        var prueba2 = "((D.D*)|('.CHARSET.')|('.CHARSET.')|(=)|(<.>)|(<)|(>)|(>.=)|(<.=)|(\\+)|(-)|(O.R)|(\\*)|(A.N.D)|(M.O.D)|(D.I.V)|(N.O.T)|(\\(.\\*)|(\\*.\\))|(;)|(\\.)|({)|(})|(\\()|(\\))|([)|(])|(\\..\\.)|(:)|(,)|(:.=)|(L.(L|D)*).#)";
                        Expresiones_Regulares.ST_Sintactico(st_SINTACTICO, operadores, expresion_TokensS);
                        var arbol_Sintactico = Helpers.GenerarArbol(st_SINTACTICO, operadores, expresion_TokensS);
                    }

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
        }
    }
}
