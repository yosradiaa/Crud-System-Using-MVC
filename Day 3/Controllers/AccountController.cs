using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace Day_3.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Login(string UserName) 
        {
            if(UserName == null) 
            {
                return View();
            }
            else
            {
                Claim c1=new Claim(ClaimTypes.Name, UserName);
                Claim c2=new Claim(ClaimTypes.Role, "Admin");
                ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                ci.AddClaim(c1);
                ci.AddClaim(c2);
                 

                ClaimsPrincipal cp = new ClaimsPrincipal(ci);
               await  HttpContext.SignInAsync(cp);
                return RedirectToAction("Index", "Home");
            }
           

        }
        public async Task < IActionResult> Logout()
        {
             await HttpContext.SignOutAsync();
            return RedirectToActionPermanent("Index","Home");
        }
    }
}
