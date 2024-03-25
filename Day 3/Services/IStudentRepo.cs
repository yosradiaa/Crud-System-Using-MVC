using Day_3.Models;

namespace Day_3.Services
{
    public interface IStudentRepo
    {
        List<Student> GetAll();
        Student GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
    }
}
