using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public interface Ipersonalrep
    {
        Task<IEnumerable<personal>> GetAllPersonal();
        Task<personal> GetDetails(int id);
        Task<bool> InsertPersonal(personal personal);
        Task<bool> UpdatePersonal(personal personal);
        Task<bool> DeletePersonal(personal personal);

    }
}
