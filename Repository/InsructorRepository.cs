using ITISchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ITISchool.Repository
{
    public class InsructorRepository : IInsructorRepository
    {
        ITISchoolContext context;
        public InsructorRepository(ITISchoolContext _context) 
        {
            context = _context;
        }
        
        public List<Instructor> GetAllWhitDepartmentCourse()
        {
            return context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .ToList();
        }

        public Instructor ByIdWhitDepartmentCourse(int id)
        {
            var ins = context.Instructors
                .Include(i => i.Department)
                .Include(i => i.Course)
                .FirstOrDefault(i => i.Id == id);
            return ins == null ? null : ins;
        }

        public List<Instructor> Search(string name)
        {
            return context.Instructors.Where(e => e.Name.Contains(name)).ToList();
        }

        public InstructorDepartmentCourse GetInstructorForEdit(int id)
        {
            var instructor = context.Instructors.FirstOrDefault(d => d.Id == id);
            if (instructor == null) return null;
            return new InstructorDepartmentCourse
            {
                Id = instructor.Id,
                Name = instructor.Name,
                Salary = instructor.Salary,
                Imag = instructor.Imag,
                DeptId = instructor.DeptId,
                CrsId = instructor.CrsId,
                departments = context.Departments.ToList(),
                Course = context.Courses.ToList()
            };
        }

        public bool UpdateInstructor(InstructorDepartmentCourse model)
        {
            var existingInstructor = context.Instructors.Find(model.Id);
            if (existingInstructor == null) return false;

            existingInstructor.Name = model.Name;
            existingInstructor.Salary = model.Salary;
            existingInstructor.Imag = model.Imag ?? "1.jpg";
            existingInstructor.DeptId = model.DeptId;
            existingInstructor.CrsId = model.CrsId;

            context.Instructors.Update(existingInstructor);
            context.SaveChanges();
            return true;
        }

        public InstructorDepartmentCourse PrepareNewInstructor()
        {
            return new InstructorDepartmentCourse
            {
                departments = context.Departments.ToList(),
                Course = context.Courses.ToList()
            };
        }

        public void PopulateDropdowns(InstructorDepartmentCourse model)
        {
            model.departments = context.Departments.ToList();
            model.Course = context.Courses.ToList();
        }

        public void AddInstructor(InstructorDepartmentCourse model)
        {
            Instructor ins = new Instructor
            {
                Name = model.Name,
                Salary = model.Salary,
                Imag = model.Imag ?? "1.jpg",
                DeptId = model.DeptId,
                CrsId = model.CrsId
            };

            context.Instructors.Add(ins);
        }

        public bool DeleteInstructor(int id)
        {
            var instructor = context.Instructors.Find(id);
            if (instructor == null) return false;

            context.Instructors.Remove(instructor);

            return true;
        }
    }
}