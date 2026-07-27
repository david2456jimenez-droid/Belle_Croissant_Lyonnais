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
                    "WHERE Direccion_Usuario.Usuario_ID = @Usuario_ID AND Direccion.Lugar = @Lugar";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario_ID", usuarioId);
                    comando.Parameters.AddWithValue("@Lugar", tipo);

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
                 "WHERE Direccion_Usuario.Usuario_ID = @Usuario_ID AND Direccion.Lugar = @Lugar";

            using (SqlCommand comando = new SqlCommand(consulta, conexion, transaccion))
            {
                comando.Parameters.AddWithValue("@Usuario_ID", usuarioId);
                comando.Parameters.AddWithValue("@Lugar", tipo);
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
                    if (ExisteDireccion(idUsuario, direccion.Lugar))
                    {
                        int direccionId = ObtenerDireccionIdPorTipo(idUsuario, direccion.Lugar, conexion, transaccion);

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
                        string consulta = "INSERT INTO Direccion (Lugar, Direccion, Preferencia) " +
                            "OUTPUT INSERTED.Direccion_ID " +
                            "VALUES (@Lugar, @direccion, @preferencia)";

                        SqlCommand comando = new SqlCommand(consulta, conexion, transaccion);
                        comando.Parameters.AddWithValue("@Lugar", direccion.Lugar);
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
                string consulta = "SELECT Direccion.Direccion_ID, Direccion.Lugar, Direccion.Direccion, Direccion.Preferencia " +
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
                            direccion.Lugar = reader["Lugar"].ToString();
                            direccion.Direccion_ = reader["Direccion"].ToString();
                            direccion.Preferencia = Convert.ToBoolean(reader["Preferencia"]);

                            direcciones.Add(direccion);
                        }
                    }
                }
            }

            return direcciones;
        }

        public bool MarcarComoFavorita(int direccionId, int usuarioId)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    string consultaQuitar = "UPDATE Direccion SET Preferencia = 0 " +
                        "WHERE Direccion_ID IN (SELECT Direccion_ID FROM Direccion_Usuario WHERE Usuario_ID = @Usuario_ID)";

                    SqlCommand cmdQuitar = new SqlCommand(consultaQuitar, conexion, transaccion);
                    cmdQuitar.Parameters.AddWithValue("@Usuario_ID", usuarioId);
                    cmdQuitar.ExecuteNonQuery();

                    string consultaMarcar = "UPDATE Direccion SET Preferencia = 1 WHERE Direccion_ID = @Direccion_ID";

                    SqlCommand cmdMarcar = new SqlCommand(consultaMarcar, conexion, transaccion);
                    cmdMarcar.Parameters.AddWithValue("@Direccion_ID", direccionId);
                    cmdMarcar.ExecuteNonQuery();

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}
