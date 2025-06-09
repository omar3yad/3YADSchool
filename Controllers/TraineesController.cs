using ITISchool.Models;
using ITISchool.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ITISchool.Controllers
{
    public class TraineesController : Controller
    {
        ITraineeRepository traineeRepository;

        public TraineesController(ITraineeRepository trrepo)
        {
            //IdentityUser
             traineeRepository = trrepo;
        }

        public IActionResult Index()
        {
            List<Trainee> trainees = traineeRepository.GetAll();
            return View("Index", trainees);
        }

        public IActionResult ById(int Id)
        {
            var trainee = traineeRepository.ByIdWithDepartmentCrsResultsCourse(Id);
            if (trainee == null)
                return NotFound();
            return View("Details", trainee);
        }

        public IActionResult Edit(int Id)
        {
            var model = traineeRepository.GetForEdit(Id);
            return model == null ? NotFound() : View("Edit", model);
        }

        [HttpPost]
        public IActionResult SaveTrainee(TraineeDepartment model)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                //foreach (var error in errors)
                //{
                //    Console.WriteLine(error);
                //}
                traineeRepository.PopulateDropdowns2(model);
                return View("Edit", model);
            }

            bool updated = traineeRepository.UpdateTrainee(model);
            if (!updated)
            {
                return NotFound();
            }
            traineeRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult AddTrainee()
        {
            var model = traineeRepository.PrepareNewTrainee();
            return View("New", model);
        }

        [HttpPost]
        public IActionResult SaveAdd(TraineeDepartmentCourse model)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                //foreach (var error in errors)
                //    Console.WriteLine(error);                
                traineeRepository.PopulateDropdowns(model);
                return View("New", model);
            }

            traineeRepository.AddTrainee(model);
            traineeRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            bool deleted = traineeRepository.DeleteTrainee(id);
            if (!deleted)
            {
                return NotFound();
            }
            traineeRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
