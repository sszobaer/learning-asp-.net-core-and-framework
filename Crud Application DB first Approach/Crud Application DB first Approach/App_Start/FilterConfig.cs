using System.Web;
using System.Web.Mvc;

namespace Crud_Application_DB_first_Approach
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
