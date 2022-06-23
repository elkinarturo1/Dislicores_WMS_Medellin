using Dislicores_Limpieza_Log_Automatica.Modulos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dislicores_Limpieza_Log_Automatica
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            OperacionesSQL.sp_A_Limpiar_DB();
            this.Close();
        }
    }
}
