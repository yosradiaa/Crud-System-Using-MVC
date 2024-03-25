using Day_3.Models;
using Day_3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day_3.Controllers
{
    public class StudentController : Controller
    {
        //StdeptContext db = new StdeptContext();
        //StudentRepo studentRepo = new StudentRepo();
        //DepartmentRepo departmentRepo = new DepartmentRepo();

        IStudentRepo studentRepo;
        IDepartmentRepo departmentRepo;

        public StudentController(IStudentRepo studentRepo, IDepartmentRepo departmentRepo)
        {
            this.studentRepo = studentRepo;
            this.departmentRepo = departmentRepo;
        }
        [Authorize(Roles="Admin")]
        public IActionResult Index()
        {
            //var model = db.Students.Include(a=>a.Department).ToList();
            var model = studentRepo.GetAll();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.depts = db.Departments.ToList();
            ViewBag.depts = departmentRepo.GetAll();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student) //modelbuilder
        {
            //ModelState Ensury that constarints on Student is valid
            if (!ModelState.IsValid)
            {

                studentRepo.Add(student);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depts = departmentRepo.GetAll();
                return View(student);
            }

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)

                return BadRequest();

            //Student model = db.Students.FirstOrDefault(a => a.Id == id);
            Student model=studentRepo.GetById(id.Value);
            if(model == null)
            
                return NotFound();
            //ViewBag.Depts = db.Departments.ToList();
            ViewBag.Depts = departmentRepo.GetAll();


            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Student std) 
        {
            //db.Students.Update(std);
            //db.SaveChanges();

            studentRepo.Update(std);
            return RedirectToAction("Index");
        }
    }
    
}
