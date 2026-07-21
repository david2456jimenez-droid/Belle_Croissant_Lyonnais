using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisClases
{
    public class DireccionDAO : Conexion
    {
        public bool ExisteDireccion(int usuarioId, string tipo)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT COUNT(*) FROM Direccion INNER JOIN Direccion_Usuario ON Direccion.Direccion_ID = Direccion_Usuario.Direccion_ID " +
                    "WHERE Direccion_Usuario.Usuario_ID = @Usuario_ID AND Direccion.Tipo = @Tipo";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario_ID", usuarioId);
                    comando.Parameters.AddWithValue("@Tipo", tipo);

                    int cantidad = (int)comando.ExecuteScalar();
                    return cantidad > 0;
                }
            }
        }
        private int ObtenerDireccionIdPorTipo(int usuarioId, string tipo, SqlConnection conexion, SqlTransaction transaccion)
        {
            string consulta = "SELECT Direccion.Direccion_ID " +
                 "FROM Direccion " +
                 "INNER JOIN Direccion_Usuario ON Direccion.Direccion_ID = Direccion_Usuario.Direccion_ID " +
                 "WHERE Direccion_Usuario.Usuario_ID = @Usuario_ID AND Direccion.Tipo = @Tipo";

            using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@Usuario_ID", usuarioId);
                comando.Parameters.AddWithValue("@Tipo", tipo);
                return (int)comando.ExecuteScalar();
            }
        }

        public bool AgregarDireccion(Direccion direccion, int idUsuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    if (ExisteDireccion(idUsuario, direccion.Tipo))
                    {
                        int direccionId = ObtenerDireccionIdPorTipo(idUsuario, direccion.Tipo, conexion, transaccion);

                        string consulta = @"UPDATE Direccion" +
                            "SET Direccion = @direccion, Preferencia = @preferencia" +
                            "WHERE Direccion_ID = @id";

                        SqlCommand comando = new SqlCommand(consulta, conexion, transaccion) { };
                        comando.Parameters.AddWithValue("@direccion", direccion.Direccion_);
                        comando.Parameters.AddWithValue("@preferencia", direccion.Preferencia);
                        comando.Parameters.AddWithValue("@id", direccionId);

                        comando.ExecuteNonQuery();
                    }

                    else
                    {
                        string consulta = "INSERT INTO Direccion (Tipo, Direccion, Preferencia) " +
                            "OUTPUT INSERTED.Direccion_ID " +
                            "VALUES (@tipo, @direccion, @preferencia)";

                        SqlCommand comando = new SqlCommand(consulta, conexion, transaccion);
                        comando.Parameters.AddWithValue("@tipo", direccion.Tipo);
                        comando.Parameters.AddWithValue("@direccion", direccion.Direccion_);
                        comando.Parameters.AddWithValue("@preferencia", direccion.Preferencia);

                        int nuevadireccion = (int)comando.ExecuteScalar();

                        string consulta2 = "INSERT INTO Direccion_Usuario (Direccion_ID, Usuario_ID)" +
                            "VALUES (@idDireccion, @idUsuario)";

                        SqlCommand comando2 = new SqlCommand(consulta2, conexion, transaccion);
                        comando2.Parameters.AddWithValue("@idDireccion", nuevadireccion);
                        comando2.Parameters.AddWithValue("@idUsuario", idUsuario);

                        comando2.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback(); // si algo falla, se deshacen las dos
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public List<Direccion> ObtenerDireccionesPorUsuario(int usuarioId, bool? soloFavoritos = null)
        {
            List<Direccion> direcciones = new List<Direccion>();

            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT Direccion.Direccion_ID, Direccion.Tipo, Direccion.Direccion, Direccion.Preferencia " +
                                   "FROM Direccion " +
                                   "INNER JOIN Direccion_Usuario ON Direccion.Direccion_ID = Direccion_Usuario.Direccion_ID " +
                                   "WHERE Direccion_Usuario.Usuario_ID = @Usuario_ID";

                if (soloFavoritos.HasValue)
                {
                    consulta += " AND Direccion.Preferencia = @Preferencia";
                }

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario_ID", usuarioId);

                    if (soloFavoritos.HasValue)
                    {
                        comando.Parameters.AddWithValue("@Preferencia", soloFavoritos.Value);
                    }

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Direccion direccion = new Direccion();
                            direccion.Direccion_ID = Convert.ToInt32(reader["Direccion_ID"]);
                            direccion.Tipo = reader["Tipo"].ToString();
                            direccion.Direccion_ = reader["Direccion"].ToString();
                            direccion.Preferencia = Convert.ToBoolean(reader["Preferencia"]);

                            direcciones.Add(direccion);
                        }
                    }
                }
            }

            return direcciones;
        }
    }
}
