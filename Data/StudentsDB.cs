using Microsoft.EntityFrameworkCore;
using ASPtask.Models;

namespace ASPtask.Data
{
    public class StudentsDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<University> Universities { get; set; }
        public StudentsDB(DbContextOptions<StudentsDB> options) : base(options)
        {

        }
    }
}
