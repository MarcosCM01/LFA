using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_LFA
{
    public class Prueba
    {
        public static char[] reservada_SETS = { 'S', 'E', 'T', 'S' };//OPCIONAL QUE EXISTA
        public static char[] reservada_TOKENS = { 'T', 'O', 'K', 'E', 'N', 'S' };//TIENE QUE EXISTIR
        public static List<string> lineas_Archivo = new List<string>();
        public static bool ArchivoVacio(string direccion)// verifica que el aechivo este vacio
        {
            FileInfo propiedades = new FileInfo(direccion);
            if (propiedades.Length > 0)
            {
                return true;
            }
            return false;
        }
        public static void LeerArchivo(string rutaFile)
        {
            //variables auxiliares
            var line = string.Empty;
            var no_lineaError = 0;
            var no_columnaError = 1;
            var bandera_Inicio = false;
            var letra_Inicio = ' ';
            using (StreamReader reader = new StreamReader(rutaFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    lineas_Archivo.Add(line);
                }
                reader.Close();
            }
            for (int i = 0; i < lineas_Archivo.Count; i++)
            {
                no_lineaError++;

                var linea = lineas_Archivo[i].ToCharArray();// linea es cada linea del documento

                //ANALIZO LA PRIMER PALABRA---> que SETS o TOKENS esten correctamente escritas
                if (linea.Length > 0 && bandera_Inicio == false)
                {
                    switch (linea[0])
                    {
                        case 'S':
                            if (Analizador_Reservada(reservada_SETS, linea, ref no_columnaError) != true)
                            { //si encuentra el error, me saca
                                MostrarError(no_lineaError, no_columnaError);
                                
                            }
                            no_columnaError = 1;
                            letra_Inicio = 'S';
                            break;
                        case 'T':
                            if (Analizador_Reservada(reservada_TOKENS, linea, ref no_columnaError) != true)
                            {
                                MostrarError(no_lineaError, no_columnaError);
                            }
                            no_columnaError = 1;
                            letra_Inicio = 'T';
                            break;
                        default:
                            MostrarError(no_lineaError, no_columnaError);
                            break;
                    }
                }
            

                if (linea.Length > 0 && bandera_Inicio == true)
                {
                    var contador_SETS = 0;
                    switch (letra_Inicio)
                    {
                        //QUE CUMPLA CARACTERISTICAS DE UN SET
                        case 'S':
                            if (VerificadorSETS(ref contador_SETS, lineas_Archivo, i, ref no_columnaError) != true || contador_SETS == 0)
                            {
                                MostrarError(no_lineaError, no_columnaError);
                            }
                            
                            break;
                        case 'T':
                            break;
                        default:
                            break;
                    }
                }
                if (bandera_Inicio == false)
                {
                    bandera_Inicio = true;
                }
            }
        }
        public static bool Analizador_Reservada(char[] reservada, char[] linea, ref int contador)
        {
            if (contador < reservada.Length)
            {
                //no_columnaError++;
                if (linea[contador] == reservada[contador])
                {
                    contador++;
                    return Analizador_Reservada(reservada, linea, ref contador);
                }
            }
            if (contador == reservada.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool VerificadorSETS(ref int cont_SETS, List<string> archivo, int posicionActual, ref int no_columnaError) 
        {
            while (archivo[posicionActual].Contains("TOKENS") != true)
            {
                var linea_TMP = archivo[posicionActual].ToCharArray();
                var verificador_Estructura = true; //variable que vea que tenga: LETRA = TERMINALES
                var contador_Letras = 0;
                var contador_CharSETS = 0;
                var igual_Encontrado = false;
                var flag_segundoPunto = false;
                var flag_Cierra = false;
                for (int i = 0; i < linea_TMP.Length; i++)
                {
                    if (char.IsLetter(linea_TMP[i]) && igual_Encontrado == false)
                    {
                        contador_Letras++;
                    }
                    switch (linea_TMP[i])
                    {
                        case '.':
                            if (i == 0 || i == linea_TMP.Length - 1)// verifico: No sea el primero o el ultimo
                            {  
                                verificador_Estructura = false;
                            }
                            if (i + 1 < linea_TMP.Length)
                            {
                                if (linea_TMP[i + 1] != '.' && flag_segundoPunto == false)//verifico primer punto y segundo punto
                                {
                                    verificador_Estructura = false;
                                }
                                if (linea_TMP[i + 1] == '.' && flag_segundoPunto == false)//Si hay concatenado mas de 2 puntos
                                {
                                    flag_segundoPunto = true;
                                }
                            }
                            break;
                        case '=':
                            if (i == 0 || i == linea_TMP.Length - 1 || contador_Letras == 0 || igual_Encontrado == true)// verifico que no sea el primero o el ultimo (si es asi, falta el ID o la definicion)
                            {
                                verificador_Estructura = false;
                            }
                            igual_Encontrado = true;
                            break;
                        case '\'':
                            if (i == 0 || i == linea_TMP.Length) //si es el primero o el ultimo
                            {
                                verificador_Estructura = false;
                            }
                            if (i + 2 < linea_TMP.Length)
                            {
                                if (char.IsLetterOrDigit(linea_TMP[i + 1]) == false || linea_TMP[i + 2] != '\'')
                                {
                                    verificador_Estructura = false;
                                }
                            }
                            break;
                        case '+':
                            if (i == 0 || i == linea_TMP.Length) // si es el primero o el ultimo
                            {
                                verificador_Estructura = false;
                                break;
                            }
                            if (i-1 > 0 && i+1 < linea_TMP.Length)// si no tiene comillas a la izquierda o derecha
                            {
                                if (linea_TMP[i-1] != '\'' && linea_TMP[i+1] != '\'')
                                {
                                    verificador_Estructura = false;
                                }
                            }
                            if (i - 5 > 0)//para que venga el mas, debe de estar concatenado antes por ..
                            {
                                if (linea_TMP[i - 5] != '.' && linea_TMP[i - 4] != '.')
                                {
                                    verificador_Estructura = false;
                                }
                            }
                            break;
                        case '(':
                            if (i == 0 || i == linea_TMP.Length)
                            {
                                verificador_Estructura = false;
                                break;
                            }
                            var x = i+1;
                            while (x < linea_TMP.Length)
                            {
                                if (char.IsDigit(linea_TMP[x]) != true)
                                {
                                    verificador_Estructura = false;
                                }
                                else
                                {
                                    contador_CharSETS++;
                                }
                                if (linea_TMP[x]== ')')
                                {
                                    flag_Cierra = true;
                                }
                                x++;
                            }
                            break;
                    }
                    no_columnaError++;
                    cont_SETS++;
                }
                igual_Encontrado = false;
                posicionActual++;
                //caso de que no tenga error el set
                if (verificador_Estructura != true)
                {
                    return false;
                }
            }
            return true;
        }

        public static void MostrarError(int no_Linea, int no_columnaError) //CASO NO SE CUMPLIO LA GRAMATICA
        {
            MessageBox.Show("ERROR EN EL ARCHIVO CARGADO, en la linea " + no_Linea + ", columna " + no_columnaError);//AGREGAR no_Columna
        }
    }
}
