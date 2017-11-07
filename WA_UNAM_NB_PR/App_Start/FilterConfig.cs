using System.Web;
using System.Web.Mvc;

namespace WA_UNAM_NB_PR
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
