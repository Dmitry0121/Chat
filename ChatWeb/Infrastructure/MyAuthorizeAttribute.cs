using System.Web;
using System.Web.Mvc;

namespace ChatWeb.Infrastructure
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public MyAuthorizeAttribute()
        { }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["Login"] != null)
                return true;
            return false;
        }
    }
}