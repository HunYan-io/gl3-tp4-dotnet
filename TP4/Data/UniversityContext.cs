using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP4.Models;

namespace TP4.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        static private UniversityContext? instance = null;
        private UniversityContext(DbContextOptions o) : base(o)
        {
            Debug.WriteLine("Instantiated University Context");
        }
        static public UniversityContext Instantiate_UniversityContext()
        {
            if (instance != null) return instance;
            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlite(@"Data Source=D:\Temp\tp4.db");
            instance = new UniversityContext(optionsBuilder.Options);
            return instance;
        }
    }
}
