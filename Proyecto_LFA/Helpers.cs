using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_LFA
{
    public class Helpers
    {
        public static char[] reservada_SETS = { 'S', 'E', 'T', 'S'};//OPCIONAL QUE EXISTA
        public static char[] reservada_TOKENS = { 'T', 'O', 'K', 'E', 'N', 'S' };//TIENE QUE EXISTIR
        public static bool ArchivoVacio(string direccion)// verifica que el aechivo este vacio
        {
            FileInfo propiedades = new FileInfo(direccion);
            if (propiedades.Length >0)
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
                    no_lineaError++;
                   
                    var linea = line.ToCharArray();// linea es cada linea del documento

                    //ANALIZO LA PRIMER PALABRA---> que SETS y TOKENS esten correctamente escritas
                    if (linea.Length > 0 && bandera_Inicio == false)
                    {
                        switch (linea[0])
                        {
                            case 'S':
                                if (Analizador_Reservada(reservada_SETS, linea, 1, ref no_columnaError) != true)
                                { //si encuentra el error, me saca
                                    MostrarError(no_lineaError, no_columnaError);
                                }
                                letra_Inicio = 'S';
                                break;
                            case 'T':
                                if (Analizador_Reservada(reservada_TOKENS, linea, 1, ref no_columnaError) != true)
                                {
                                    MostrarError(no_lineaError, no_columnaError);
                                }
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
                               break;
                            case 'T':
                                break;
                            default:
                                break;
                        }
                    }
                    bandera_Inicio = true;
                }
                reader.Close();
            }
            
        }
        public static bool Analizador_Reservada(char[] reservada, char[] linea, int contador, ref int no_columnaError) 
        {
            if (contador < reservada.Length)
            {
                no_columnaError++;
                if (linea[contador] == reservada[contador])
                {
                    return Analizador_Reservada(reservada, linea, contador + 1, ref no_columnaError);
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

        public static void MostrarError(int no_Linea, int no_columnaError) //CASO NO SE CUMPLIO LA GRAMATICA
        {
            MessageBox.Show("ERROR EN EL ARCHIVO CARGADO, en la linea "+no_Linea +", columna " +no_columnaError);//AGREGAR no_Columna
        }
    }
}
