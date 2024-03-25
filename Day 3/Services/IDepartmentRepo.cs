using Day_3.Models;

namespace Day_3.Services
{
    public interface IDepartmentRepo 
    {
        List<Department> GetAll();
        Department GetById(int id);
        Department GetByName(string name);
        void Add(Department department);
        void Update(Department department);
        void Delete(Department department);
        void Delete( int id);

    }
}
