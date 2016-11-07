using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Puestos_de_Trabajo.Models;
using Puestos_de_Trabajo.Negocio;

namespace Negocio
{
    public class Gestor
    {
        public List<PuestoTrabajo> ListadoCategoria()
        {
            return new DalPuestoTrabajo().ListadoCategoria();
        }
        public PuestoTrabajo ObtenerPuestoTrabajo(Int32 IdPuestoTrabajo)
        {
            return new DalPuestoTrabajo().ObtenerCategoria(IdPuestoTrabajo);
        }
        public List<PuestoTrabajo> ListadoPuestoTrabajoPaginacion(Int32 Pagina, Int32 NroRegistros)
        {
            return new DalPuestoTrabajo().ListadoCategoriaPaginacion(Pagina, NroRegistros);
        }
        public Int32 ListadoPuestoTrabajoPaginacionCount(Int32 NroRegistros)
        {
            return new DalPuestoTrabajo().ListadoCategoriaPaginacionCount(NroRegistros);
        }
        public Int32 CantidadRegistros()
        {
            return new DalPuestoTrabajo().CantidadRegistros();
        }
    }
}
