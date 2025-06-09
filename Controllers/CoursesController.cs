using ITISchool.Models;
using ITISchool.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITISchool.Controllers
{
    public class CoursesController : Controller
    {
        CourseRepository _courseRepository = new CourseRepository();

        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);
        }

        public IActionResult ById(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null) return NotFound();
            return View("Details", course);
        }

        public IActionResult Edit(int id)
        {
            var model = _courseRepository.GetCourseForEdit(id);
            return model == null ? NotFound() : View("Edit", model);
        }

        [HttpPost]
        public IActionResult SaveCourses(CourseDepartmentInstructors cdi)
        {
            if (!ModelState.IsValid)
            {
                _courseRepository.PopulateDropdowns(cdi);
                return View("Edit", cdi);
            }

            bool updated = _courseRepository.UpdateCourse(cdi);
            if (!updated)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _courseRepository.DeleteCourse(id);
            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
