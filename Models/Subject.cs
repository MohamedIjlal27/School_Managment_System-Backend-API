using System.ComponentModel.DataAnnotations;

namespace school_managment_system_backend.Models
{
    public class Subject
    {
        [Key]
        public int subId { get; set; }
        public int subName { get; set; }
    }
}
