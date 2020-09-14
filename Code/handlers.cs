
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ecommerce_MVC_Core.Code
{
    public class handlers
    {
        protected  void OnException(ExceptionContext filterContext)
        {
            var lastException = filterContext.Exception;
            // Do something with exception, e.g. Log it or  mail to Admin.      
            filterContext.ExceptionHandled = true;      // So that no one else will be bothered      
            filterContext.Result = new ViewResult() { ViewName = "Error" };
        }
    }
}
