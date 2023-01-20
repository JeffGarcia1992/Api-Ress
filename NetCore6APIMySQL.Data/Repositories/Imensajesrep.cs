using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public interface Imensajesrep
    {
        Task<IEnumerable<mensajes>> GetAllMensajes();
        Task<mensajes> GetDetails(int id);
        Task<bool> InsertMensajes(mensajes mensajes);
        Task<bool> UpdateMensajes(mensajes mensajes);
        Task<bool> DeleteMensajes(mensajes mensajes);
    }
}
