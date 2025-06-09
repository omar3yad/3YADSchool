namespace ITISchool.Models
{
    public class CourseDepartmentInstructors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int hours { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        
        public int DeptID { get; set; }
        public List<int> InstIDs { get; set; } = new List<int>(); 
        public List<Department> departments { get; set; } = new List<Department>();
        public List<Instructor> instructors { get; set; } = new List<Instructor>();

        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();
    }
}
