using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data
{
    public class MySQLConfiguration
    {
        public MySQLConfiguration(string connetionString)
        {
            ConnectionString = connetionString;
        }
        public string ConnectionString { get; set; }
    }
    
}
