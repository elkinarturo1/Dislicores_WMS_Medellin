using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared
{
    public class ArchivoCargadoModel
    {
        public string nombreArchivo { get; set; }

        public string archivoBase64 { get; set; }

        public byte[] archivoBytes { get; set; }

    }
}
