using EvenFinder.Data;
using EvenFinder.Data2.Abstract;
using EvenFinder.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EvenFinder.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public ActionResult Login()
        {
            if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUser = await _userRepository.Users
                    .FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                
                if(isUser != null)
                {
                    var userClaims = new List<Claim>();
                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.UserId.ToString())); 
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.UserName ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.UserData, isUser.Image ?? ""));

                    if(isUser.Email == "info@omerbirgul.com")
                    {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.
                        AuthenticationScheme);


                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                        );

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "E-mail or Password is WRONG");
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


        public IActionResult Register()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Event");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register( RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await _userRepository.Users
                    .FirstOrDefaultAsync(x => x.UserName == model.UserName || x.Email == model.Email);
                if(user == null)
                {
                    _userRepository.CreateUser(new User
                    {
                        Name = model.Name,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = model.Password,
                        Image = model.Image,
                        UserName = model.UserName,
                    });

                    return RedirectToAction("Login");

                }
                else
                {
                    ModelState.AddModelError("", "UserName or E-mail already used");
                }
                
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}
