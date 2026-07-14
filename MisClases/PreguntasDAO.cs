using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MisClases
{
    public class PreguntasDAO : Conexion
    {
        public List<Preguntas> MostrarPreguntas()
        {
            List<Preguntas> Lista_preg = new List<Preguntas>();
            using (SqlConnection conexion = ObtenerConexion())
            {
                conexion.Open();
                string consulta_preg = "SELECT * FROM Pregunta";

                using (SqlCommand comando = new SqlCommand(consulta_preg, conexion))
                {
                    comando.CommandType = CommandType.Text;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Preguntas preguntas = new Preguntas
                            {
                                Pregunta_ID = Convert.ToInt32(reader["Pregunta_ID"]),
                                Pregunta = reader["Pregunta"].ToString(),
                            };

                            Lista_preg.Add(preguntas);
                        }
                    }
                }
            }
            return Lista_preg;
        }
    }
}
