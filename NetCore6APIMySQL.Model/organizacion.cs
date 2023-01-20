using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Model
{
    public class organizacion
    {
        public int id_organizacion { get; set; }
        public string descripcion { get; set; }
        public string mision { get; set; }
        public string vision { get; set; }
        public string valores { get; set; }
    }
}
