using ITISchool.Models;
using ITISchool.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITISchool.Controllers
{
    public class InstructorController : Controller
    {
        IInsructorRepository instructorRepository;
        public InstructorController(IInsructorRepository _insructorRepository) 
        {
            instructorRepository = _insructorRepository;
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = instructorRepository.GetAllWhitDepartmentCourse(); ;
            return View("Index", instructors);
        }

        public IActionResult GetById(int id)
        {
            var instructor = instructorRepository.ByIdWhitDepartmentCourse(id);
            if (instructor == null)
            {
                return NotFound(); 
            }
            return View("Details", instructor);
        }


        public IActionResult Search(string s)
        {
            List<Instructor> instructors = instructorRepository.Search(s);
            return View("Index", instructors);
        }

        public IActionResult Edit(int Id)
        {
            var model = instructorRepository.GetInstructorForEdit(Id);
            return model == null ? NotFound() : View("Edit", model);
        }

        public IActionResult SaveEdit(InstructorDepartmentCourse model)
        {
            if (!ModelState.IsValid)
            {
                instructorRepository.PopulateDropdowns(model);
                return View("AddInstructor", model);
            }

            bool updated = instructorRepository.UpdateInstructor(model);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddInstructor()
        {
            var model = instructorRepository.PrepareNewInstructor();
            return View("AddInstructor", model);
        }

        [HttpPost]
        public IActionResult SaveInstructor(InstructorDepartmentCourse model)
        {
            if (!ModelState.IsValid)
            {
                instructorRepository.PopulateDropdowns(model);
                return View("AddInstructor", model);
            }

            instructorRepository.AddInstructor(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bool deleted = instructorRepository.DeleteInstructor(id);
            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}