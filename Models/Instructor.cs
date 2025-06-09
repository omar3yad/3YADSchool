using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITISchool.Models
{
    public class Instructor
    {
        [Required]
        [MinLength(3)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imag { get; set; }
        public int Salary { get; set; }

        public int DeptId { get; set; }
        public Department Department { get; set; }

        public int CrsId { get; set; }
        public Course Course { get; set; }


    }
}
