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
    public class mensajesrep : Imensajesrep
    {
        private readonly MySQLConfiguration _connectionString;
        public mensajesrep(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteMensajes(mensajes mensajes)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM mensajes WHERE id_mensajes= @id";

            var result = await db.ExecuteAsync (sql, new {Id = mensajes.id_mensajes } );

            return result > 0;


        }

        public async Task<IEnumerable<mensajes>> GetAllMensajes()
        {
            var db = dbConnection();

            var sql = @" SELECT id_mensajes, remitente, telefono, asunto, cuerpo from mensajes";

            return await db.QueryAsync<mensajes>(sql, new {});
        }

        public async Task<mensajes> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id_mensajes, remitente, telefono, asunto, cuerpo 
                        from mensajes 
                        WHERE id_mensajes= @id ";

            return await db.QueryFirstOrDefaultAsync<mensajes>(sql, new {Id = id});
        }

        public async Task<bool> InsertMensajes(mensajes mensajes)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO mensajes (remitente, telefono, asunto, cuerpo)
                        VALUES (@mensajes, @remitente, @telefono, @asunto) ";

            var result = await db.ExecuteAsync(sql, new 
                { mensajes.remitente, mensajes.telefono, mensajes.asunto, mensajes.cuerpo});

            return result > 0;
        }

        public async Task<bool> UpdateMensajes(mensajes mensajes)
        {
            var db = dbConnection();

            var sql = @" UPDATE mensajes 
                        SET remitente=@remitente,
                            telefono=@telefono,
                            asunto=@asunto,
                            cuerpo=@cuerpo
                            WHERE id_mensajes = @id";

            var result = await db.ExecuteAsync(sql, new
            { mensajes.remitente, mensajes.telefono, mensajes.asunto, mensajes.cuerpo, mensajes.id_mensajes });

            return result > 0;
        }

       
    }
}
