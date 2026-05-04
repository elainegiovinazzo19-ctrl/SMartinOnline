using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMartinOnline.DAL
{
    public class BitacoraDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=SMartinOnline;Integrated Security=True";

        public void RegistrarAccion(int? idUsuario, string nombreUsuario, string accion, bool exitoso)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Bitacora (IdUsuario, NombreUsuario, Accion, Fecha, Exitoso) VALUES (@IdUsuario, @NombreUsuario, @Accion, @Fecha, @Exitoso)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdUsuario", (object)idUsuario ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@Accion", accion);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now);
                cmd.Parameters.AddWithValue("@Exitoso", exitoso);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
