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
        public static bool ArchivoVacio(string direccion) 
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
            var line = string.Empty;
            using (StreamReader reader = new StreamReader(rutaFile))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    MessageBox.Show(line);
                }
            }
        }
    }
}
