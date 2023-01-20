using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public interface Iproductosrep
    {
        Task<IEnumerable<productos>> GetAllProductos();
        Task<productos> GetDetails(int id);
        Task<bool> InsertProductos(productos productos);
        Task<bool> UpdateProductos(productos productos);
        Task<bool> DeleteProductos(productos productos);

    }
}
