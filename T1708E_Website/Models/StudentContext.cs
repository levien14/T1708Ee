using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T1708E_Website.Models;

namespace T1708E_Website.Controllers
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options):base(options)
        {
                   }
        public DbSet<Student> Students { get; set; }
    }
}
