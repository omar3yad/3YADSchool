using ITISchool.Models;

namespace ITISchool.Repository
{
    public interface IInsructorRepository
    {
        public List<Instructor> GetAllWhitDepartmentCourse();

        public Instructor ByIdWhitDepartmentCourse(int id);

        public List<Instructor> Search(string name);
        public InstructorDepartmentCourse GetInstructorForEdit(int id);

        public bool UpdateInstructor(InstructorDepartmentCourse model);

        public InstructorDepartmentCourse PrepareNewInstructor();
        public void PopulateDropdowns(InstructorDepartmentCourse model);

        public void AddInstructor(InstructorDepartmentCourse model);

        public bool DeleteInstructor(int id);
    }
}
