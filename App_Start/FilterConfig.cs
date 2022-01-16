using System.Web;
using System.Web.Mvc;

namespace PPPK_Delivery_6_CosmosOsoba
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
