using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TP4.Models;

namespace TP4.Data
{
    public interface IStudentRepository<TEntity> where TEntity : class
    {
        TEntity? Get(int id); IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool Remove(TEntity entity);
        IEnumerable<String> GetCourses();
        IEnumerable<TEntity> GetByCourse(string id);
    }
    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly UniversityContext universityContext;
        public StudentRepository(UniversityContext universityContext)
        {
            this.universityContext = universityContext;
        }
        public bool Add(Student entity)
        {
            universityContext.Set<Student>().Add(entity);
            universityContext.SaveChanges();

            return true;
        }
        public IEnumerable<Student> Find(Expression<Func<Student, bool>> predicate)
        {
            return universityContext.Set<Student>().Where(predicate);
        }
        public Student? Get(int id)
        {

            return universityContext.Set<Student>().Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return universityContext.Set<Student>().ToList();
        }

        public IEnumerable<String> GetCourses()
        {
            return universityContext
                .Student.Select(s => s.course).Distinct().ToList();
        }

        public IEnumerable<Student> GetByCourse(string course)
        {
            return universityContext
                .Student.Where(s => s.course == course).ToList();
        }

        public bool Remove(Student entity)
        {
            universityContext.Set<Student>().Remove(entity);
            universityContext.SaveChanges();
            return true;
        }

    }
}
