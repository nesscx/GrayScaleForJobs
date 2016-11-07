using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Puestos_de_Trabajo.Negocio
{
    public class DalConexion
    {
        public static String ObtenerConexion()
        {
            String conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=CRUD;Trusted_Connection=True;";
            return conexion;
        }
    }
}