using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public interface Iorganizacionrep
    {
        Task<IEnumerable<organizacion>> GetAllOrganizacions();
        Task<organizacion> GetDetails(int id);
        Task<bool> InsertOrganizacion(organizacion organizacion);
        Task<bool> UpdateOrganizacion(organizacion organizacion);
        Task<bool> DeleteOrganizacion(organizacion organizacion);

    }
}
