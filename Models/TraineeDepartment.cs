using System.ComponentModel.DataAnnotations;

namespace ITISchool.Models
{
    public class TraineeDepartment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string Name { get; set; }

        public string Image { get; set; }

        public int Grade { get; set; }
        [Required]
        [RegularExpression(@"(Cairo|Giza)")]
        public string? Address { get; set; }

        public int DeptId { get; set; }
        public List<Department> departments { get; set; } = new List<Department>();
    }
}
