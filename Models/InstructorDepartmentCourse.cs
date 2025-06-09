namespace ITISchool.Models
{
    public class InstructorDepartmentCourse
    {
        public InstructorDepartmentCourse()
        {
            departments = new List<Department>();
            Course = new List<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public int Salary { get; set; }


        public int DeptId { get; set; }

        public int CrsId { get; set; }

        public List<Course> Course { get; set; }
        public List<Department> departments { get; set; }

    }
}
