using Day_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_3.Services
{
    public class StudentRepo : IStudentRepo
    {
        StdeptContext db = new StdeptContext();
        public List<Student> GetAll()
        {
            return db.Students.Where(a => a.Department.Status == true).Include(a=>a.Department).ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.SingleOrDefault(a=>a.Id == id);
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
             db.SaveChanges();
        }
        public void Update(Student student) { 
            db.Students.Update(student);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var m=db.Students.SingleOrDefault(a=>a.Id == id);
            db.Students.Remove(m);
            db.SaveChanges();
        }

    }
}
