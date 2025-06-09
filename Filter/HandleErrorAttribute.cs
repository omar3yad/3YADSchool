using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITISchool.Filter
{
    public class HandleErrorAttribute: Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context) 
        {
            //cach
            ViewResult viewResult =  new ViewResult();
            viewResult.ViewName = "Error";  

            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Some .Exception";
            context.Result = viewResult;
        }
    }
}
