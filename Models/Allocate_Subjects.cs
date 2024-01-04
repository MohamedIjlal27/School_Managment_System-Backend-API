using System.ComponentModel.DataAnnotations;

namespace school_managment_system_backend.Models
{
    public class Allocate_Subjects
    {
        [Key]
        public int allocatedSubId { get; set; }
        public string teacherName { get; set; }
        public string subName { get; set; }
    }
}
