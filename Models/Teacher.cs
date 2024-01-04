using System.ComponentModel.DataAnnotations;

namespace school_managment_system_backend.Models
{
    public class Teacher
    {
        [Key]
        public int teachId { get; set; }
        public string teachFirstName { get; set; }
        public string teachSecondName { get; set; }
        public string teachContactNo { get; set; }
        public string teachEmailAddress { get; set; }
    }
}
