using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puestos_de_Trabajo.Models;
using System.Data;
using System.Data.SqlClient;

namespace Puestos_de_Trabajo.Negocio
{
    public class DalPuestoTrabajo
    {
        public List<PuestoTrabajo> ListadoCategoria()
        {
            List<PuestoTrabajo> lst = new List<PuestoTrabajo>();

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();

            SqlCommand objComm = new SqlCommand("sp_ObtenerPuestosPorCategoria", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = objComm.ExecuteReader();

            while (dr.Read())
            {
                PuestoTrabajo obj = new PuestoTrabajo();
                obj.Categoria.descripcion = (dr["Categoría"]).ToString();
                obj.cargo = (dr["Cargo"]).ToString();
                obj.Empresa.nombre = (dr["Compañía"]).ToString();
                obj.Empresa.localidad = (dr["Localidad"]).ToString();

                lst.Add(obj);
            }

            cnn.Close();
            return lst;
        }

        public PuestoTrabajo ObtenerCategoria(Int32 IdCategoria)
        {
            PuestoTrabajo obj = null;

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();

            SqlCommand objComm = new SqlCommand("sp_ObtenerCategoriaPorId", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            SqlParameter pEstado = new SqlParameter("@IdCategoria", IdCategoria);
            objComm.Parameters.Add(pEstado);

            SqlDataReader dr = objComm.ExecuteReader();

            if (dr.Read())
            {
                obj = new PuestoTrabajo();
                obj.Categoria.descripcion = (dr["Categoría"]).ToString();
                obj.cargo = (dr["Cargo"]).ToString();
                obj.Empresa.nombre = (dr["Compañía"]).ToString();
                obj.Empresa.localidad = (dr["Localidad"]).ToString();
            }

            cnn.Close();
            return obj;
        }
        
        public List<PuestoTrabajo> ListadoCategoriaPaginacion(Int32 Pagina, Int32 NroRegistros)
        {
            List<PuestoTrabajo> lst = new List<PuestoTrabajo>();

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();

            SqlCommand objComm = new SqlCommand("sp_ListadoCategoria_Paginacion", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            SqlParameter pNroRegistros = new SqlParameter("@NroRegistros", NroRegistros);
            SqlParameter pPagina = new SqlParameter("@Pagina", Pagina);
            objComm.Parameters.Add(pNroRegistros);
            objComm.Parameters.Add(pPagina);

            SqlDataReader dr = objComm.ExecuteReader();

            while (dr.Read())
            {
                PuestoTrabajo obj = new PuestoTrabajo();
                obj.cargo = (dr["p.Cargo"]).ToString();
                obj.Categoria.descripcion = (dr["Categoría"]).ToString();
                obj.Empresa.nombre = (dr["Compañía"]).ToString();
                obj.Empresa.localidad = (dr["Localidad"]).ToString();

                lst.Add(obj);
            }

            cnn.Close();
            return lst;
        }

        public Int32 ListadoCategoriaPaginacionCount(Int32 NroRegistros)
        {
            Int32 NroPaginas = 0;

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();

            SqlCommand objComm = new SqlCommand("sp_ListadoCategoria_Paginacion_Count", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            SqlParameter pNroRegistros = new SqlParameter("@NroRegistros", NroRegistros);
            objComm.Parameters.Add(pNroRegistros);

            NroPaginas = Convert.ToInt32(objComm.ExecuteScalar());

            cnn.Close();
            return NroPaginas;
        }

        public Int32 CantidadRegistros()
        {
            Int32 cantidad = 0;

            SqlConnection cnn = new SqlConnection(DalConexion.ObtenerConexion());
            cnn.Open();

            SqlCommand objComm = new SqlCommand("sp_CantidadRegistros", cnn);
            objComm.CommandType = CommandType.StoredProcedure;

            cantidad = Convert.ToInt32(objComm.ExecuteScalar());

            return cantidad;
        }
    }
}



