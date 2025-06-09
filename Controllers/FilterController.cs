using ITISchool.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ITISchool.Controllers
{
   // [HandleError]
    public class FilterController : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Exception Index");
        }
    }
}
