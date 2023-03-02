using Library.Models;
using Library.RepositoryPattern.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
    public class AuthController : Controller
    {
        IRepository<AppUser> _userRepository;
        public AuthController(IRepository<AppUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUser user)
        {
            if (_userRepository.Any(x => x.UserName == user.UserName && user.Status != Enums.DataStatus.Deleted))
            {
                AppUser selectedUser = _userRepository.Default(x => x.UserName == user.UserName && user.Status != Enums.DataStatus.Deleted);
                bool check = BCrypt.Net.BCrypt.Verify(user.Password, selectedUser.Password);
                if (check)
                {
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim("userName",selectedUser.UserName),
                        new Claim("userId",selectedUser.ID.ToString()),
                        new Claim("role",selectedUser.role.ToString())
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    if (selectedUser.role == Enums.Role.admin)
                    {
                        return RedirectToAction("Index", "home", new { area = "Management" });
                    }
                    else if (selectedUser.role == Enums.Role.user)
                    {
                        return RedirectToAction("Index", "home");
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        
}
}
