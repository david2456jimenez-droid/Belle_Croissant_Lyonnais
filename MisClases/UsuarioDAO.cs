using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MisClases
{
    public class UsuarioDAO : Conexion
    {
        public Usuario ObtenerUsuarioPorEmail(string email)
        {
            Usuario usuario1 = null;
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT * FROM Usuario WHERE Email=@email";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario1 = new Usuario();
                            usuario1.Pregunta_ID = Convert.ToInt32(reader["Pregunta_ID"]);
                            usuario1.Email = reader["Email"].ToString();
                            usuario1.Contraseña = reader["Contraseña"].ToString();
                            usuario1.Nombre = reader["Nombre"].ToString();
                            usuario1.Apellido = reader["Apellido"].ToString();
                            usuario1.Suscripcion = Convert.ToBoolean(reader["Suscripcion"]);
                            usuario1.Respuesta_Seguridad = reader["Respuesta_Seguridad"].ToString();
                            usuario1.Metodo_Entrega = reader["Metodo_Entrega"].ToString();
                        }
                    }
                }
            }
            return usuario1;
        }


        public bool validacion_email(Usuario usuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consulta = "SELECT Email FROM Usuario WHERE Email=@email";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@email", usuario.Email);

                    SqlDataReader reader = comando.ExecuteReader();
                    return reader.Read();
                }
            }
        }

        public bool registrar_usuario(Usuario usuario)
        {
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consulta = "INSERT INTO Usuario(Pregunta_ID,Nombre,Apellido,Email,Contraseña,Suscripcion, Respuesta_Seguridad)" +
                    "VALUES(@Pregunta_ID,@Nombre,@Apellido,@Email,@Contraseña,@Suscripcion, @Respuesta_Seguridad)";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Pregunta_ID", usuario.Pregunta_ID);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@Email", usuario.Email);
                    comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    comando.Parameters.AddWithValue("@Suscripcion", usuario.Suscripcion);
                    comando.Parameters.AddWithValue("@Respuesta_Seguridad", usuario.Respuesta_Seguridad);

                    int guardar = comando.ExecuteNonQuery();

                    return guardar > 0;
                }
            }
            //---------------------
        }
    }
}
