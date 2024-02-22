using EvenFinder.Data2.Abstract;
using EvenFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
