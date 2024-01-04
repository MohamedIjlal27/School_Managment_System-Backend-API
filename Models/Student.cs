using System.ComponentModel.DataAnnotations;

namespace school_managment_system_backend.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public string? contactperson { get; set; }
        public string? contactno { get; set; }
        public string? emailaddress { get; set; }
        public DateTime dateofbirth { get; set; }
        public int age { get; set; }
        public string? classroom { get; set; }

    }
}
