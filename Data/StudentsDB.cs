using Microsoft.EntityFrameworkCore;
using ASPtask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
