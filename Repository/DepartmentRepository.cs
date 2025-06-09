using ITISchool.Models;
using Microsoft.EntityFrameworkCore;

namespace ITISchool.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ITISchoolContext context;        
        public DepartmentRepository(ITISchoolContext _context)
        {
            context = _context;

        }

        public List<Department> GetAll()
        {           
            var x = context.Departments.ToList();
            return x;
        }

        public Department ById(int id)
        {
                var x = context.Departments.FirstOrDefault(t => t.Id == id);
                return x;
        }
        public Department ByIdWithDeptInstTrain(int id)
        {
            return context.Departments
                .Include(d => d.instructors)
                .Include(d => d.courses)
                .Include(d => d.trainees)
                .FirstOrDefault(t => t.Id == id);
            
        }
    }
}
