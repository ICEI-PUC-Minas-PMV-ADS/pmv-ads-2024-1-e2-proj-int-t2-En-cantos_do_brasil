using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Encantos_do_Brasil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Encantos_do_Brasil.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

using System.Threading.Tasks;

namespace ProjetoNovo.Controllers
{
    public interface IAuthenticationService
    {
        Task<bool> Login(string email, string senha);
        Task Logout();
    }

    public class Login_LogoutController : Controller
    {
        private readonly IAuthenticationService _authService;

        public Login_LogoutController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        // GET: /Login_Logout/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Login_Logout/Login
        [HttpPost]
        public async Task<IActionResult> Login(Usuario model)
        {
            if (ModelState.IsValid)
            {
                // Aguarda a conclusão da tarefa
                var success = await _authService.Login(model.Email, model.Senha);
                if (success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
                }
            }
            return View(model);
        }

        // GET: /Login_Logout/Logout
        public IActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Login");
        }
    }
}