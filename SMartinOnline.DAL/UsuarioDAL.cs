using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMartinOnline.Entidades;

namespace SMartinOnline.DAL
{
    public class UsuarioDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=SMartinOnline;Integrated Security=True";

        public Usuario ObtenerPorUsuario(string nombreUsuario)
        {
            Usuario usuario = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Usuario WHERE NombreUsuario = @NombreUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = (int)reader["IdUsuario"];
                    usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                    usuario.Contrasena = reader["Contrasena"].ToString();
                    usuario.Rol = reader["Rol"].ToString();
                    usuario.Activo = (bool)reader["Activo"];
                    usuario.IntentosLogin = (int)reader["IntentosLogin"];
                }
            }
            return usuario;
        }

        public void ActualizarIntentosLogin(int idUsuario, int intentos)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET IntentosLogin = @Intentos WHERE IdUsuario = @IdUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Intentos", intentos);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void BloquearUsuario(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET Activo = 0 WHERE IdUsuario = @IdUsuario";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
