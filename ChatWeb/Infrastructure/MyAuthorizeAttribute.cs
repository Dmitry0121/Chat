using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Data.Entity;


using System.Configuration;

using System.Web.Security;

using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Web.Mvc;

namespace ChatWeb.Infrastructure
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        public MyAuthorizeAttribute()
        { }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (System.Web.HttpContext.Current.Session["Login"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}