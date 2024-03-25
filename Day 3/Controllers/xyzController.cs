using Day_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day_3.Controllers
{
    public class xyzController : Controller
    {
        IDepartmentRepo   _departmentRepo;
        public xyzController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public IActionResult Index( [FromServices]IDepartmentRepo dept)
        {
            return Content($"Action param {dept.GetHashCode().ToString()} Constructor Injection {_departmentRepo.GetHashCode().ToString()} ");
        }
    }
}
