using System.Web;
using System.Web.Mvc;

namespace CNT2_2210900089_VuVietAnh
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
