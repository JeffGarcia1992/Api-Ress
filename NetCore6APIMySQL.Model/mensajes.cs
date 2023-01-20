using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Model
{
    public class mensajes
    {
        public int id_mensajes { get; set; }
        public string remitente { get; set; }
        public string telefono { get; set; }
        public string asunto { get; set; }
        public string cuerpo { get; set; }
    }
}
