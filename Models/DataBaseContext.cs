using Microsoft.EntityFrameworkCore;

namespace school_managment_system_backend.Models
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options):base(options)
        {
                        
        }
        public DbSet<Allocate_Classroom> Allocate_Classroom { get; set; }
        public DbSet<Allocate_Subjects> Allocate_Subjects { get; set; }
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        

    }
}
