using Dapper;
using Google.Protobuf.Reflection;
using MySql.Data.MySqlClient;
using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public class productosrep : Iproductosrep
    {
        private readonly MySQLConfiguration _connectionString;
        public productosrep(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteProductos(productos productos)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM productos WHERE id_productos= @id";

            var result = await db.ExecuteAsync (sql, new {Id = productos.id_productos } );

            return result > 0;


        }

        public async Task<IEnumerable<productos>> GetAllProductos()
        {
            var db = dbConnection();

            var sql = @" SELECT id_productos, nombre, codigo, descripcion from productos";

            return await db.QueryAsync<productos>(sql, new {});
        }

        public async Task<productos> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id_productos, nombre, codigo, descripcion 
                        from productos 
                        WHERE id_productos= @id ";

            return await db.QueryFirstOrDefaultAsync<productos>(sql, new {Id = id});
        }

        public async Task<bool> InsertProductos(productos productos)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO productos (nombre, codigo, descripcion )
                        VALUES (@nombre, @codigo, @descripcion ) ";

            var result = await db.ExecuteAsync(sql, new 
                { productos.nombre, productos.codigo, productos.descripcion });

            return result > 0;
        }

        public async Task<bool> UpdateProductos(productos productos)
        {
            var db = dbConnection();

            var sql = @" UPDATE productos 
                        SET nombre=@nombre,
                            codigo=@codigo,
                            descripcion=@descripcion,
                            WHERE id_productos = @id";

            var result = await db.ExecuteAsync(sql, new
            { productos.nombre, productos.codigo, productos .descripcion, productos.id_productos});

            return result > 0;
        }

       
    }
}
