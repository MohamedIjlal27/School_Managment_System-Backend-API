using System.ComponentModel.DataAnnotations;

namespace school_managment_system_backend.Models
{
    public class Allocate_Classroom
    {
        [Key]
        public int allocateClassRoomId { get; set; }
        public string teachName { get; set; }
        public string clsRoom { get; set; }
    }
}
