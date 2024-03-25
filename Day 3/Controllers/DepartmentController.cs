using Day_3.Models;
using Day_3.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Day_3.Controllers
{
    public class DepartmentController : Controller
    {
        //StdeptContext db= new StdeptContext();
        //DepartmentRepo departmentRepo = new DepartmentRepo();

        IDepartmentRepo departmentRepo;
        public DepartmentController(IDepartmentRepo _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }

        public IActionResult Index()
        {
            //var model = db.Departments.ToList();
            var model = departmentRepo.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department Dept)
        {
            departmentRepo.Add(Dept);
            return RedirectToAction("Index");
            //if (!ModelState.IsValid)
            //{
            //    //db.Departments.Add(Dept);
            //    try
            //    {
            //        departmentRepo.Add(Dept);
            //    }
            //    catch (Exception ex)
            //    {
            //        ModelState.AddModelError("", ex.Message);
            //        return View(Dept);
            //    }
            //    return RedirectToAction("Index");
            //}
            //return View(Dept);
        }
        public IActionResult CheckDeptId(int DeptId)
        {
            //var model=db.Departments.FirstOrDefault(a=>a.DeptId==DeptId);
            var model=departmentRepo.GetById(DeptId);
            if (model != null)
            {
                return Json(false);
                //int x = db.Departments.Max(a => a.DeptId);
                //return Json($"you can't use {DeptId} u can use {x+1}");
            }
            else
                return Json(true);
        }
        public IActionResult CheckDeptName(string Name, int DeptId)
        {
            //var model = db.Departments.FirstOrDefault(a=>a.Name==Name);
            var model=departmentRepo.GetByName(Name);
            if (model == null)
            {
                return Json(true);
            }
            else
                return Json(false);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("U MUST PROVIDE ID");
            }
            //var model = db.Departments.FirstOrDefault(a => a.DeptId == id.Value);
            var model = departmentRepo.GetById(id.Value);   
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
      
       }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Enter ID");
            }
            ////var model = db.Departments.FirstOrDefault(a => a.DeptId == id.Value);

            //if (model == null)
            //{
            //    return NotFound();
            //}
            //db.Departments.Remove(model);
            //db.SaveChanges();

            departmentRepo.Delete(id.Value);
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            //var model = db.Departments.FirstOrDefault(a => a.DeptId == id.Value);
            var model = departmentRepo.GetById(id.Value);
            
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Department Dept,int ?id)
        {
            //db.Departments.Update(Dept);
            //db.SaveChanges();
            Dept.DeptId = id.Value;
            departmentRepo.Update(Dept);
            return RedirectToAction("Index");

        }

    }
}
