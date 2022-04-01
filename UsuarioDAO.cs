using AppDatabaseADO;
using AppDatabaseDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;


namespace AppDatabaseDLL
{
    public class UsuarioDAO
    {
        private Database db;

        public void insertUsuario(Usuario usuario)
        {
            string strDate = usuario.UsuarioDataNasc.ToString("yyyy-MM-dd");
            string insertQuery = String.Format("INSERT INTO tb_usuario VALUES (default, '{0}', '{1}', '{2}');",
                                                  usuario.UsuarioNome,
                                                  usuario.UsuarioCargo,
                                                  strDate);
            using (db = new Database())
            {
                db.ExecuteCommand(insertQuery);
            }
        }

        public void updateUsuario(Usuario usuario)
        {
            string strDate = usuario.UsuarioDataNasc.ToString("yyyy-MM-dd");
            string updateQuery = String.Format("UPDATE tb_usuario " +
                                                "SET usuarioNome     = '{0}', " +
                                                    "usuarioCargo    = '{1}', " +
                                                    "usuarioDataNasc = '{2}' " +
                                                "WHERE usuarioId = {3}",
                                                 usuario.UsuarioNome,
                                                 usuario.UsuarioCargo,
                                                 strDate,
                                                 usuario.UsuarioId);

            using (db = new Database())
            {
                db.ExecuteCommand(updateQuery);
            }
        }

        public void deleteUsuario(Usuario usuario)
        {
            string deleteQuery = String.Format("DELETE FROM tb_usuario WHERE usuarioId = {0}", usuario.UsuarioId);
            using (db = new Database())
            {
                db.ExecuteCommand(deleteQuery);
            }
        }

        public List<Usuario> selectAllUsuarios()
        {
            using (db = new Database())
            {
                string selectAllQuery = "SELECT * FROM tb_usuario";
                var dataReader = db.ReturnCommand(selectAllQuery);
                return convertReader2List(dataReader);
            }

        }

        public List<Usuario> convertReader2List(MySqlDataReader dataReader)
        {
            var listUsuarios = new List<Usuario>();
            while (dataReader.Read())
            {
                var usuario = new Usuario()
                {
                    UsuarioId = int.Parse(dataReader["usuarioId"].ToString()),
                    UsuarioNome = dataReader["usuarioNome"].ToString(),
                    UsuarioCargo = dataReader["usuarioCargo"].ToString(),
                    UsuarioDataNasc = DateTime.Parse(dataReader["usuarioDataNasc"].ToString())
                };
                listUsuarios.Add(usuario);
            }
            return listUsuarios;
        }

    }
}