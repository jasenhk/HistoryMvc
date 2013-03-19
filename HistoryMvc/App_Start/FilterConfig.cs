using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace HistoryMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IUnityContainer container)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}