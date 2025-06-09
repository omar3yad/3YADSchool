using System.ComponentModel.DataAnnotations.Schema;

namespace ITISchool.Models
{
    public class CrsResult
    {
        public int Id { get; set; }

        public int Degree { get; set; }


        public int CrsId { get; set; }
        public Course Course { get; set; }

        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

    }
}
