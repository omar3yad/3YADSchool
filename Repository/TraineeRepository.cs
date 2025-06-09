using ITISchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ITISchool.Repository
{
    public class TraineeRepository : ITraineeRepository
    {

        ITISchoolContext context;
        public TraineeRepository(ITISchoolContext _context) 
        {
            context = _context;
        
        }

        public List<Trainee> GetAll()
        {
            return context.Trainees
                          .Include(t => t.Department)
                          .ToList();
        }

        public Trainee ByIdWithDepartmentCrsResultsCourse(int id)
        {
            return context.Trainees
                          .Include(t => t.Department)
                          .Include(t => t.CrsResults)
                               .ThenInclude(cr => cr.Course)
                          .FirstOrDefault(t => t.Id == id);
        }

        public TraineeDepartment? GetForEdit(int id)
        {
            var trainee = context.Trainees
                .FirstOrDefault(t => t.Id == id);

            if (trainee == null) return null;

            return new TraineeDepartment
            {
                Id = trainee.Id,
                Name = trainee.Name,
                Grade = trainee.Grade,
                Address = trainee.Address,
                DeptId = trainee.DeptId,
                departments = context.Departments.ToList(),
            };
        }

        public bool UpdateTrainee(TraineeDepartment model)
        {
            var trainee = context.Trainees
                .FirstOrDefault(t => t.Id == model.Id);

            if (trainee == null) return false;

            trainee.Name = model.Name;
            trainee.Grade = model.Grade;
            trainee.Address = model.Address;
            trainee.DeptId = model.DeptId;
            return true;
        }

        public TraineeDepartmentCourse PrepareNewTrainee()
        {
            return new TraineeDepartmentCourse
            {
                departments = context.Departments.ToList()
            };
        }

        public void PopulateDropdowns(TraineeDepartmentCourse model)
        {
            model.departments = context.Departments.ToList();
        }        public void PopulateDropdowns2(TraineeDepartment model)
        {
            model.departments = context.Departments.ToList();
        }

        public void AddTrainee(TraineeDepartmentCourse model)
        {
            var trainee = new Trainee
            {
                Name = model.Name,
                Grade = model.Grade,
                Address = model.Address,
                DeptId = model.DeptId,
                Image = model.Image
            };

            context.Add(trainee);
        }

        public bool DeleteTrainee(int id)
        {
            var trainee = context.Trainees.Find(id);
            if (trainee == null) return false;

            context.Remove(trainee);
            return true;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}