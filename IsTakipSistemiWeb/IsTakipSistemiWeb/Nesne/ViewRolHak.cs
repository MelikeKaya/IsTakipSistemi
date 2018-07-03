using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsTakipSistemiWeb.Nesne
{
    public class ViewRolHak
    {
        public int rolhak_id { get; set; }
        public int rol_id { get; set; }
        public int hak_id { get; set; }
        public string rol_ad { get; set; }
        public string hak_ad { get; set; }
        public string link_id { get; set; }
        public string ust_link_id { get; set; }
    }
}