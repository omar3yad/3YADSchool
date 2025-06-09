using System.Collections.Generic;
using ITISchool.Models;
using ITISchool.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITISchool.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepository IDepartmentRepository; 
        public DepartmentController(IDepartmentRepository trrepo)
        {
                IDepartmentRepository = trrepo;
        }

       // [Authorize]
        public IActionResult Index()
        {
            List<Department> list = IDepartmentRepository.GetAll();
            return View("Index", list);
        }
        public IActionResult ById(int id) { 
        
            var dep = IDepartmentRepository.ByIdWithDeptInstTrain(id);
            return View("Detail", dep);
        }
    }
}
