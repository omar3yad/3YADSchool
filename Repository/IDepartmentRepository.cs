using ITISchool.Models;

namespace ITISchool.Repository
{
    public interface IDepartmentRepository 
    {
       public List<Department> GetAll();
       public Department ById(int id);
        public Department ByIdWithDeptInstTrain(int id);
    }
}
