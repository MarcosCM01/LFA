﻿using System;
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
        public static List<string> gramatica = new List<string>();
        public static bool ArchivoVacio(string direccion)// verifica que el aechivo este vacio
        {
            //var result = gramatica.Find(x => );
            FileInfo propiedades = new FileInfo(direccion);
            if (propiedades.Length >0)
            {
               return true;
            }
            return false;
        }
        public static void LeerArchivo(string rutaFile, Nodo arbol_Sets, Nodo arbol_Tokens, Nodo arbol_Actions, Nodo arbol_Error, List<char>operadores) 
        {
            //variables auxiliares
            var line = string.Empty;
            var no_lineaError = 0;
            var no_columnaError = 0;
            var primer_Caracter = new char();
            //LEO EL ARCHIVO
            using (StreamReader reader = new StreamReader(rutaFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    gramatica.Add(line);
                }
                reader.Close();
            }
            var primer_Linea = gramatica[0].ToCharArray();
            //ANALIZO LA PRIMER PALABRA---> que SETS o TOKENS esten correctamente escritas
            switch (primer_Linea[0])
            {
                case 'S':
                    if (Analizador_Reservada(reservada_SETS, primer_Linea, 1, ref no_columnaError) != true)
                    { //si encuentra el error, me saca
                        MostrarError(no_lineaError, no_columnaError);
                    }
                    primer_Caracter = 'S';
                    break;
                case 'T':
                    if (Analizador_Reservada(reservada_TOKENS, primer_Linea, 1, ref no_columnaError) != true)
                    {
                        MostrarError(no_lineaError, no_columnaError);
                    }
                    primer_Caracter = 'T';
                    break;
                default:
                    MostrarError(no_lineaError, no_columnaError);
                    break;
            }
            no_lineaError++;
            for (int i = 1; i < gramatica.Count; i++)
            {
                var linea = gramatica[i].ToCharArray();// linea es cada linea del documento
                if (primer_Caracter== 'S')//HAY SETS-->
                {
                    while (!gramatica[i].Contains("TOKEN"))//gramatica[i] == LINEA DEL ARCHIVO
                    {
                        CompararArbol(arbol_Sets, gramatica[i], ref no_columnaError, operadores);
                        i++;
                    }
                }
                else//EMPIEZA DESDE TOKENS
                {

                }
                
       
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

        public static void CompararArbol(Nodo arbol, string linea, ref int columna, List<char> operadores) 
        {
            //INORDEN
            if (arbol != null)
            {
                CompararArbol(arbol.hijo_izquierdo, linea, ref columna, operadores);
                //COMPARAR EL NODO
                
                if (arbol.padre.id == '*')//ES REPETITIVO
                {
                    while (linea[columna] != arbol.padre.id)//AVANZAR EN LOS ESPACIOS
                    {
                        if (linea[columna] == arbol.padre.id)
                        {
                            columna++;
                        }
                    }
                    if (columna== 0)
                    {

                    }
                }
                else if (arbol.padre.id == '+')
                {
                    //BUSCAR EL SIMBOLO TERMINAL (ARBOL.ID) EN LA LISTA
                    switch (arbol.id)
                    {
                        case 'L':
                            while ( !char.IsLetter(linea[columna]))
                            {
                                columna++;
                                //IF BANDERA_ERROR == TRUE ---> DEVOLVER ERROR
                            }
                            break;
                        case 'C':
                            if (linea[columna] != arbol.id)
                            {
                                //TIRAR ERROR
                            }
                            break;
                        default:
                            break;
                    }
                    //YA TENIENDO EL SIMBOLO TERMINAL--> HAGO UN WHILE(!)
                }
                CompararArbol(arbol.hijo_derecho, linea, ref columna, operadores);
            }
        }
        public static void MostrarError(int no_Linea, int no_columnaError) //CASO NO SE CUMPLIO LA GRAMATICA
        {
            MessageBox.Show("ERROR EN EL ARCHIVO CARGADO, en la linea "+no_Linea +", columna " +no_columnaError);//AGREGAR no_Columna
        }
    }
}
