using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.Commercial_Effectiveness
{
    public class UN_Update_Model
    {

        public List<T_Equivalencias_Criterios_UN> listado_Equiv_UN { get; set; }
        public List<T_Equivalencias_Criterio_Nielse_D> listado_Equiv_NielsenD { get; set; }
        public List<T_Equivalencias_NoTocar> listado_Equiv_NoTocar { get; set; }


    }
}
