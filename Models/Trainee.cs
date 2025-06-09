using System.ComponentModel.DataAnnotations;
namespace ITISchool.Models
{
    public class Trainee
    { 
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        public string Name { get; set; }

        //[Required]
        //[RegularExpression(@"\w+\.(png|jpg)")]
        public string Image { get; set; }   

        public int Grade { get; set; }

        [Required]
        [RegularExpression(@"(Cairo|Giza)")]
        public string? Address { get; set; }

        public int DeptId { get; set; }

        public Department? Department { get; set; }

        public ICollection<CrsResult>? CrsResults { get; set; }
    }
}
