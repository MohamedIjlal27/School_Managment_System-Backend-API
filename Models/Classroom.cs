using System.ComponentModel.DataAnnotations;

namespace school_managment_system_backend.Models
{
    public class Classroom
    {
        [Key]
        public int clsID { get; set; }
        public string clsName { get; set; }
    }
}
