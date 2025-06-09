using System.ComponentModel.DataAnnotations.Schema;

namespace ITISchool.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public int hours { get; set; } 

        public int Degree{ get; set; }
        public int MinDegree{ get; set; }


        public int DeptId { get; set; }
        public Department Department { get; set; } = new Department();

        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
        public ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();


    }
}
