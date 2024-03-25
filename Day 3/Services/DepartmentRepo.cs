using Day_3.Models;
using Microsoft.EntityFrameworkCore;

namespace Day_3.Services
{
    public class DepartmentRepo:IDepartmentRepo
    {
        StdeptContext db = new StdeptContext();
        public List<Department> GetAll()
        {
            return db.Departments.Where(a=>a.Status==true).ToList();
        }
        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);
        }
        public Department GetByName(string name)
        {
            return db.Departments.SingleOrDefault(a => a.Name == name);
        }
        public void Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var m = db.Departments.SingleOrDefault(a => a.DeptId == id);
            db.Departments.Update(m);
            m.Status = false;
            db.SaveChanges();
        }

        //List<DepartmentRepo> IDepartmentRepo.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        public void Delete(Department department)
        {
            throw new NotImplementedException();
        }

        
    }
}
