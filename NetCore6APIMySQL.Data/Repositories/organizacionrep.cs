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
    public class organizacionrep : Iorganizacionrep
    {
        private readonly MySQLConfiguration _connectionString;
        public organizacionrep(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteOrganizacion(organizacion organizacion)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM organizacion WHERE id_organizacion= @id";

            var result = await db.ExecuteAsync (sql, new {Id = organizacion.id_organizacion } );

            return result > 0;


        }

        public async Task<IEnumerable<organizacion>> GetAllOrganizacions()
        {
            var db = dbConnection();

            var sql = @" SELECT id_organizacion, descripcion, mision, vision, valores from organizacion";

            return await db.QueryAsync<organizacion>(sql, new {});
        }

        public async Task<organizacion> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id_organizacion, descripcion, mision, vision, valores 
                        from organizacion 
                        WHERE id_organizacion= @id ";

            return await db.QueryFirstOrDefaultAsync<organizacion>(sql, new {Id = id});
        }

        public async Task<bool> InsertOrganizacion(organizacion organizacion)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO organizacion (descripcion, mision, vision, valores)
                        VALUES (@descripcion, @mision, @vision, @valores) ";

            var result = await db.ExecuteAsync(sql, new 
                { organizacion.descripcion, organizacion.mision, organizacion.vision, organizacion.valores});

            return result > 0;
        }

        public async Task<bool> UpdateOrganizacion(organizacion organizacion)
        {
            var db = dbConnection();

            var sql = @" UPDATE organizacion 
                        SET descripcion=@descripcion,
                            mision=@mision,
                            vision=@vision,
                            valores=@valores
                            WHERE id_organizacion = @id";

            var result = await db.ExecuteAsync(sql, new
            { organizacion.descripcion, organizacion.mision, organizacion.vision, organizacion.valores, organizacion.id_organizacion });

            return result > 0;
        }
    }
}
