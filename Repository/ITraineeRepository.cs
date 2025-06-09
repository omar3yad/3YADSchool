using ITISchool.Models;

namespace ITISchool.Repository
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetAll();

        public Trainee ByIdWithDepartmentCrsResultsCourse(int id);
        public void AddTrainee(TraineeDepartmentCourse model);
        public bool UpdateTrainee(TraineeDepartment model);
        public bool DeleteTrainee(int id);
        public void Save();

        public TraineeDepartment? GetForEdit(int id);            
        public TraineeDepartmentCourse PrepareNewTrainee();
        public void PopulateDropdowns(TraineeDepartmentCourse model);
        public void PopulateDropdowns2(TraineeDepartment model);

        }
    }