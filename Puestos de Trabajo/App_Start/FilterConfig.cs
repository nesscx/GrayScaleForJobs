using System.Web;
using System.Web.Mvc;

namespace Puestos_de_Trabajo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
