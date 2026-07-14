using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace MisClases
{
    public class Conexion
    {
        private readonly string CadenaConexion;

        public Conexion()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
        }

        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(CadenaConexion);
        }
    }
}
