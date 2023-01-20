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
    public class personalrep : Ipersonalrep
    {
        private readonly MySQLConfiguration _connectionString;
        public personalrep(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeletePersonal(personal personal)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM personal WHERE id_personal= @id";

            var result = await db.ExecuteAsync (sql, new {Id = personal.id_personal } );

            return result > 0;


        }

        public async Task<IEnumerable<personal>> GetAllPersonal()
        {
            var db = dbConnection();

            var sql = @" SELECT id_personal, identificacion, nombres, apellidos, direccion, telefono from personal";

            return await db.QueryAsync<personal>(sql, new {});
        }

        public async Task<personal> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id_personal, identificacion, nombres, apellidos, direccion, telefono 
                        from personal 
                        WHERE id_personal= @id ";

            return await db.QueryFirstOrDefaultAsync<personal>(sql, new {Id = id});
        }

        public async Task<bool> InsertPersonal(personal personal)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO personal (identificacion, nombres, apellidos, direccion, telefono )
                        VALUES (@identificacion, @nombres, @apellidos, @direccion, @telefono ) ";

            var result = await db.ExecuteAsync(sql, new 
                { personal.identificacion, personal.nombres, personal.apellidos, personal.direccion, personal.telefono});

            return result > 0;
        }

        public async Task<bool> UpdatePersonal(personal personal)
        {
            var db = dbConnection();

            var sql = @" UPDATE mensajes 
                        SET identificacion=@identificacion,
                            nombres=@nombres,
                            apellidos=@apellidos,
                            direccion=@direccion
                            telefono=@telefono
                            WHERE id_mensajes = @id";

            var result = await db.ExecuteAsync(sql, new
            { personal.identificacion, personal.nombres, personal.apellidos, personal.direccion, personal.telefono, personal.id_personal });

            return result > 0;
        }

       
    }
}
