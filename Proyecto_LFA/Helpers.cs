//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using System.Windows.Forms;

//namespace Proyecto_LFA
//{
//    public class MensajeError 
//    {
//        public static string mensaje_Error;
//    }
//    public class Helpers
//    {
//        public static char[] reservada_SETS = { 'S', 'E', 'T', 'S'};//OPCIONAL QUE EXISTA
//        public static char[] reservada_TOKENS = { 'T', 'O', 'K', 'E', 'N', 'S' };//TIENE QUE EXISTIR
//        public static char[] reservada_ACTIONS = { 'A', 'C', 'T', 'I', 'O', 'N', 'S' };//TIENE QUE EXISTIR
//        public static char[] reservada_RESERVADAS = { 'R', 'E', 'S', 'E', 'R', 'V', 'A', 'D', 'A','S', '(', ')' };//TIENE QUE EXISTIR
//        public static List<string> gramatica = new List<string>();//LISTA QUE ALMACENA EL ARCHIVO
//        public static bool ArchivoVacio(string direccion)// verifica que el aechivo este vacio
//        {
//            //var result = gramatica.Find(x => );
//            FileInfo propiedades = new FileInfo(direccion);
//            if (propiedades.Length >0)
//            {
//               return true;
//            }
//            return false;
//        }
//        public static void LeerArchivo(string rutaFile, Nodo arbol_Sets, Nodo arbol_Tokens, Nodo arbol_Actions, Nodo arbol_Error) 
//        {
//            //variables auxiliares
//            var line = string.Empty;
//            var no_columnaError = 0;
//            var primer_Caracter = new char();
//            //LEO EL ARCHIVO
//            using (StreamReader reader = new StreamReader(rutaFile))
//            {
//                while ((line = reader.ReadLine()) != null)
//                {
//                    gramatica.Add(line.Trim('\t'));
//                }
//                reader.Close();
//            }
//            var primer_Linea = gramatica[0].ToCharArray();
//            //ANALIZO LA PRIMER PALABRA---> que SETS o TOKENS esten correctamente escritas
//            switch (primer_Linea[0])
//            {
//                case 'S':
//                    if (Analizador_Reservada(reservada_SETS, primer_Linea, 0, ref no_columnaError, 1) != true)
//                    { //si encuentra el error, me saca
//                        MostrarError(MensajeError.mensaje_Error);
//                    }
//                    primer_Caracter = 'S';
//                    break;
//                case 'T':
//                    if (Analizador_Reservada(reservada_TOKENS, primer_Linea, 0, ref no_columnaError, 1) != true)
//                    {
//                        MostrarError(MensajeError.mensaje_Error);
//                    }
//                    primer_Caracter = 'T';
//                    break;
//                default:
//                    MensajeError.mensaje_Error = $"ERROR EN LA LINEA {1}, COLUMNA {1}: NO VENIA LA DEFINICION CORRECTA DE TOKENS.";
//                    MostrarError(MensajeError.mensaje_Error);
//                    break;
//            }
//            var i = 1;
//            if (MensajeError.mensaje_Error == null)//NO EXISTIO ERROR AL INICIO
//            {
//                while (i < gramatica.Count && MensajeError.mensaje_Error == null)
//                {
//                    var inicio_Gramatica = i;
//                    if (primer_Caracter == 'S')//HAY SETS-->
//                    {
//                        //-------------------------------------------------LOGICA CUANDO INICIA CON SETS---------------------------------------------
//                        while (!gramatica[i].Contains("TOKENS"))//gramatica[i] == LINEA DEL ARCHIVO
//                        {
//                            no_columnaError = 0;
//                            var filtro = gramatica[i].ToCharArray();
//                            if (filtro[filtro.Length-1]=='\''  || filtro[filtro.Length - 1] == ')' || filtro[filtro.Length - 1] == ' ')
//                            {
//                                CompararArbol(arbol_Sets, gramatica[i], ref no_columnaError, Form1.st_SETS, i);
//                                i++;
//                            }
//                            else
//                            {
//                                MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {filtro.Length -1}: DEFINICION INCOMPLETA";
//                                MostrarError(MensajeError.mensaje_Error);
//                            }
//                        }
//                        if (i- inicio_Gramatica == 0)//ERROR. NO VINO NINGUN SET
//                        {
//                            MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {1}: NO VENIA NINGUN SET DEFINIDO.";
//                            MostrarError(MensajeError.mensaje_Error);
//                        }
//                        inicio_Gramatica = i;
//                    }
//                    while (!gramatica[i].Contains("ACTIONS"))
//                    {
//                        no_columnaError = 0;
//                        CompararArbol(arbol_Tokens, gramatica[i], ref no_columnaError, Form1.st_TOKENS, i);
//                        i++;
//                    }
//                    if (i - inicio_Gramatica == 0)//ERROR. NO VINO NINGUN TOKEN
//                    {
//                        MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {no_columnaError}: NO VENIA NINGUN TOKEN DEFINIDO DEFINIDO.";
//                        MostrarError(MensajeError.mensaje_Error);
//                    }

//                    if (Analizador_Reservada(reservada_ACTIONS, gramatica[i].ToCharArray(), 0, ref no_columnaError, i) == true)
//                    {
//                        no_columnaError = 0;
//                        i++;
//                        if (Analizador_Reservada(reservada_RESERVADAS, gramatica[i].ToCharArray(), 0, ref no_columnaError, i) == true)
//                        {
//                            i++;
//                            if (gramatica[i] == "{")
//                            {
//                                i++;
//                                var contador_Actions = i;
//                                while (!gramatica[i].Contains("}") || i < gramatica.Count)
//                                {
//                                    no_columnaError = 0;
//                                    CompararArbol(arbol_Actions, gramatica[i], ref no_columnaError, Form1.st_ACTIONS, i);
//                                    i++;
//                                }
//                                if (i - contador_Actions == 0 || i == gramatica.Count)
//                                {
//                                    MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {1}: NO VENIA LA LLAVE FINAL";
//                                    MostrarError(MensajeError.mensaje_Error);
//                                }
//                            }
//                            else
//                            {
//                                MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {1}: NO VENIA LA LLAVE INICIAL";
//                                MostrarError(MensajeError.mensaje_Error);
//                            }
//                        }
//                        else
//                        {
//                            MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {no_columnaError}: NO VENIA LA PALABRA RESERVADAS ACOMPAÑANDO A ACTIONS.";
//                            MostrarError(MensajeError.mensaje_Error);
//                        }
//                    }
//                    else
//                    {
//                        MensajeError.mensaje_Error = $"ERROR EN LA LINEA {i}, COLUMNA {no_columnaError}: NO VENIA LA PALABRA ACTIONS O ESCRITA INCORRECTAMENTE.";
//                        MostrarError(MensajeError.mensaje_Error);
//                    }

//                    if (i < gramatica.Count)
//                    {
//                        while (i < gramatica.Count)
//                        {
//                            no_columnaError = 0;
//                            CompararArbol(arbol_Error, gramatica[i], ref no_columnaError, Form1.st_ERROR, i);
//                            i++;
//                        }
//                    }
//                    if (MensajeError.mensaje_Error != null)
//                    {
//                        break;
//                    }
//                }
//            }
//        }
//        public static bool Analizador_Reservada(char[] reservada, char[] linea, int contador, ref int no_columnaError, int linea_Error) 
//        {
//            if (contador < reservada.Length)
//            {
//                no_columnaError++;
//                if (linea[contador] == reservada[contador])
//                {
//                    return Analizador_Reservada(reservada, linea, contador + 1, ref no_columnaError, linea_Error);
//                }
//            }
//            if (contador == reservada.Length)
//            {
//                return true;
//            }
//            MensajeError.mensaje_Error = $"ERROR EN LA LINEA{linea_Error}, COLUMNA{no_columnaError}: NO VENIA {reservada[contador]}.";
//            return false;
//        }

//        static bool bandera_IzquierdaOR = false;
//        static bool bandera_DerechaOR = false;
//        //static Nodo nodo_Mas = new Nodo('#');
//        public static void CompararArbol(Nodo arbol, string linea, ref int columna, List<char>st, int linea_Error) 
//        {
//            //VERIFICAR CASOS OR, MAS GRANDE Y POR GRANDE
            
//            //INORDEN
//            if (arbol != null)
//            {
//                CompararArbol(arbol.hijo_izquierdo, linea, ref columna, st, linea_Error);
//                //CASO TOKENS ---> COMPARAR EL NODO (MAS GRANDE)
//                //if (arbol.padre != null)
//                //{
//                //    if (arbol.padre.id == '+' && arbol.padre.padre.padre == null)
//                //    {
//                //        nodo_Mas = arbol.padre;
//                //    }
//                //}
//                //CASO OR 1--> QUE EL LADO IZQUIERDO ERA EL BUENO
//                if (arbol.id == '|' && bandera_IzquierdaOR == true)
//                {
//                    var izq = OR_CaminoBueno(arbol);
//                    bandera_IzquierdaOR = false;
//                    CompararArbol(izq, linea, ref columna, st, linea_Error);
//                }
//                //CASO MAS GRANDE OR POR GRANDE
//                //if ((arbol.id == '*' || arbol.id == '+') && arbol.padre.padre == null && columna < linea.Length)
//                //{
//                //    CompararArbol(arbol, linea, ref columna, st, linea_Error);
//                //}
//                else if (st.Contains(arbol.id) && EsHoja(arbol)!= false)//SIMBOLO TERMINAL Y HOJA--> LOS QUE HAY QUE ANALIZAR
//                {
//                    if (arbol.padre.id == '*')
//                    {
//                        while (linea[columna] == arbol.id)//AVANZAR EN LOS ESPACIOS
//                        {
//                            columna++;
//                        }
//                    }
//                    else if (arbol.padre.id == '+')
//                    {
//                        //BUSCAR EL SIMBOLO TERMINAL (ARBOL.ID) EN LA LISTA
//                        var verificador = columna;
//                        switch (arbol.id)
//                        {
//                            case 'L':
//                                if (bandera_IzquierdaOR == false)
//                                {
//                                    while (char.IsLetter(linea[columna]))
//                                    {
//                                        columna++;
//                                    }
//                                    if (columna - verificador == 0)
//                                    {
//                                        MensajeError.mensaje_Error = $"ERROR EN LA LINEA {linea_Error}, COLUMNA {columna}: NO VENIA IDENTIFICADOR.";
//                                        MostrarError(MensajeError.mensaje_Error);
//                                    }
//                                }
//                                break;
//                            case 'N':
//                                verificador = columna;
//                                while (char.IsNumber(linea[columna]))
//                                {
//                                    columna++;
//                                    //IF BANDERA_ERROR == TRUE ---> DEVOLVER ERROR
//                                }
//                                if (columna - verificador == 0)
//                                {
//                                    MensajeError.mensaje_Error = $"ERROR EN LA LINEA {linea_Error}, COLUMNA {columna}: NO VENIA NUMERO.";
//                                    MostrarError(MensajeError.mensaje_Error);
//                                }
//                                break;
//                            case ' ':
//                                while (linea[columna] == ' ')
//                                {
//                                    columna++;
//                                }
//                                break;
//                            case 'S':
//                                while (char.IsSymbol(linea[columna]) || char.IsLetterOrDigit(linea[columna]))
//                                {
//                                    columna++;
//                                }
//                                if (columna - verificador == 0 && bandera_IzquierdaOR == false && bandera_DerechaOR == false)
//                                {
//                                    MensajeError.mensaje_Error = $"ERROR EN LA LINEA {linea_Error}, COLUMNA {columna}: NO VENIA UN NINGUN TERMINAL O SIMBOLO.";
//                                    MostrarError(MensajeError.mensaje_Error);
//                                }
//                                break;

//                        }
//                        //YA TENIENDO EL SIMBOLO TERMINAL--> HAGO UN WHILE(!)
//                    }
//                    else if (arbol.padre.id == '.')
//                    {
//                        var verificador = columna;
//                        var contador_Simbolos = 0;
//                        switch (arbol.id)
//                        {
//                            case 'S':
//                                if ((char.IsSymbol(linea[columna]) || char.IsLetterOrDigit(linea[columna]) && linea[columna+1] != 'H'))
//                                {
//                                    columna++;
//                                    contador_Simbolos++;
//                                }
//                                break;
//                        }
//                        if (contador_Simbolos == 0)
//                        {
//                            //SE HACE POR SI NO AVANZO--> NO ERA S O C
//                            if (columna - verificador == 0)
//                            {
//                                // PARA CARACTERES COMO: =, ', C, H, R, (, ), ., +, E, R, O, T, K, N 
//                                if (linea[columna] == arbol.id)
//                                {
//                                    columna++;
//                                    //CASO OR 1: IZQ-->CORRECTO, DER-->MALO
//                                    if (VerificarPadre(arbol, '|') == true)
//                                    {
//                                        bandera_IzquierdaOR = true;
//                                    }
//                                }
//                                //if (bandera_IzquierdaOR == true && arbol.padre.padre.id == '|')
//                                //{
//                                //    var padre_Original = DevolverPadreInicial(arbol);
//                                //    bandera_IzquierdaOR = true;
//                                //    bandera_DerechaOR = false;
//                                //    CompararArbol(padre_Original.hijo_derecho, linea, ref columna, st, linea_Error);
//                                //}
//                                else if (linea[columna] != arbol.id)
//                                {
//                                    //CASO OR 2: QUE EL HIJO IZQUIERDO ESTA MALO, IRSE AL DERECHO DE UNA VEZ
//                                    if (VerificarPadre(arbol, '|') == true && bandera_IzquierdaOR == false)
//                                    {
//                                        //bandera izquierda = true
//                                        bandera_DerechaOR = true;
//                                        var nodoOr = EncontrarNodoOR(arbol);//HIJO IZQ QUE TIENE COMO PADRE AL |
//                                        CompararArbol(nodoOr.hijo_derecho, linea, ref columna, st, linea_Error);
//                                        var derecho_Bueno = OR_CaminoBueno(nodoOr);
//                                        CompararArbol(derecho_Bueno, linea, ref columna, st, linea_Error);
//                                        bandera_DerechaOR = false;
//                                    }
//                                    else if (VerificarPadre(arbol, '|') == true && bandera_IzquierdaOR == false && bandera_DerechaOR == false)
//                                    {
//                                        MensajeError.mensaje_Error = $"ERROR EN LA LINEA {linea_Error}, COLUMNA {columna}: NO VENIA UN NINGUN TERMINAL O SIMBOLO.";
//                                        MostrarError(MensajeError.mensaje_Error);
//                                    }
//                                }
//                                //else
//                                //{
//                                //    ERROR.mensajeError = $"ERROR EN LA LINEA{linea_Error}, COLUMNA{columna}: SE ESPERABA UN {arbol.id}.";
//                                //}
//                            }
//                        }
//                    }
//                    //PARA EL MAS
//                    else if (linea[columna] == arbol.id)
//                    {
//                        columna++;
//                    }
//                }
//                //CASO PARA EL | DONDE YA ANALIZO EL IZQUIERDO, Y ESTABA BUENO (SETS)
//                else if (arbol.id == '|' && bandera_IzquierdaOR == true)
//                {
//                    DevolverPadreInicial(arbol);
//                    //bandera_IzquierdaOR = false;
//                    //bandera_DerechaOR = true;
//                    CompararArbol(arbol.hijo_derecho, linea, ref columna, st, linea_Error);
//                }
//                CompararArbol(arbol.hijo_derecho, linea, ref columna, st, linea_Error);
//                ////FIN DE RECORRIDO
//                //if (columna < linea.Length && nodo_Mas.id == '+')
//                //    {
//                //    nodo_Mas.id = '#';
//                //    CompararArbol(nodo_Mas, linea, ref columna, st, linea_Error);
//                //}
//            }
//        }

//        public static bool EsHoja(Nodo nodo) //SI SE UTILIZA
//        {
//            if (nodo.hijo_derecho == null && nodo.hijo_izquierdo == null)
//            {
//                return true;
//            }
//            return false;
//        }

//        static bool bandera_PADRE = false;
//        public static bool VerificarPadre(Nodo nodo, char buscado) //SI SE UTILIZA
//        {
//            while (nodo.padre != null)
//            {
//                if (nodo.padre.id == buscado)
//                {
//                    bandera_PADRE = true;
//                }
//                return VerificarPadre(nodo.padre, buscado);
//            }
//            return bandera_PADRE;
//        }
//        public static Nodo EncontrarNodoOR(Nodo nodo) //SI SE UTILIZA (CASO OR 2)
//        {
//            if (nodo.padre != null && nodo.padre.id != '|')
//            {
//                return EncontrarNodoOR(nodo.padre);
//            }
//            return nodo.padre;
//        }
//        public static Nodo DevolverPadreInicial(Nodo nodo) //VERIFICAR QUE SE UTILICE
//        {
//            while (nodo.padre != null)
//            {
//                return DevolverPadreInicial(nodo.padre);
//            }
//            return nodo;
//        }

//        public static bool banderaOR2 = false;
//        public static Nodo OR_CaminoBueno(Nodo nodo) 
//        {
//            if (nodo.hijo_derecho.id == '+' && EsHoja(nodo.hijo_derecho) == true)
//            {
//                banderaOR2 = true;
//            }
//            if (nodo.padre != null && nodo.padre.hijo_derecho != null)
//            {
//                if (nodo.padre.hijo_derecho.id == '|' || nodo.padre.hijo_izquierdo.id == '|')
//                {
//                    return OR_CaminoBueno(nodo.padre);
//                }
//            }
//            else if (nodo.padre != null && nodo.padre.hijo_derecho == null)
//            {
//                if (nodo.padre.id == '*' && banderaOR2 == false)
//                {
//                    //CASO OR(SET3)
//                    return nodo.padre;
//                }
//                else
//                {
//                    //CASO OR (SET2)
//                    banderaOR2 = false;
//                    return nodo.hijo_derecho;
//                }
//            }
//            //CASO OR (SET1)
//            return nodo.padre.hijo_derecho;
//        }

//        //POSIBLES RESULTADOS
//        public static void ArchivoCorrecto() 
//        {
//            MessageBox.Show("ARCHIVO DE PRUEBA SIN NINGUN ERROR");
//        }
//        public static void MostrarError(string mensaje) //CASO NO SE CUMPLIO LA GRAMATICA
//        {
//            MessageBox.Show(mensaje);
//            //Application.Restart();
//        }
//    }
//}
