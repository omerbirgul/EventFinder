using EvenFinder.Data2.Abstract;
using EvenFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvenFinder.Controllers
{
    public class UserController : Controller
    {
        


        public ActionResult Login()
        {
            return View();
        }

        
    }
}
