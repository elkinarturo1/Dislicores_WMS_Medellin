﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sauron_Monitor_Integraciones.Shared.WMS
{
   public  class Orders_Model
    {

        public string STORERKEY { get; set; }
        public string EXTERNORDERKEY { get; set; }
        public string TYPE { get; set; }
        public string CONSIGNEEKEY { get; set; }
        public string SUSR1 { get; set; }
        public string SUSR2 { get; set; }
        public string SUSR3 { get; set; }
        public string SUSR4 { get; set; }
        public string B_CONTACT1 { get; set; }
        public string WHSEID { get; set; }
        public string NOTES { get; set; }
        public DateTime DELIVERYDATE { get; set; }
        public string Fecha_erp { get; set; }
        public string Fecha_ION { get; set; }
        public string ION_flag { get; set; }

    }
}
