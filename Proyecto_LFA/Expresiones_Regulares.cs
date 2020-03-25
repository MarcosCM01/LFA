using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_LFA
{
    public class Expresiones_Regulares
    {
        public static void LlenarOP(List<char> operadores)
        {
            operadores.Add('*');
            operadores.Add('+');
            operadores.Add('|');
            operadores.Add('?');
            operadores.Add('(');
            operadores.Add(')');
            operadores.Add('.');//CONCATENACION
        }
        public static void Generar_ST(List<char> operadores, List<char> tipo, string expresion_Regular)
        {
            for (int i = 0; i < expresion_Regular.Length; i++)
            {
                if (!operadores.Contains(expresion_Regular[i]) && expresion_Regular[i]!= '\\' && !tipo.Contains(expresion_Regular[i]))
                {
                    tipo.Add(expresion_Regular[i]);
                }
                if (i-1 > 0)
                {
                    if (expresion_Regular[i - 1] == '\\' && !tipo.Contains(expresion_Regular[i]))
                    {
                        tipo.Add(expresion_Regular[i]);
                    }
                }
            }
        }
    }
}
