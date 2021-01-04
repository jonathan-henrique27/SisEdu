using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AplicacaoWeb.Models;
using AplicacaoWeb.Models.Model;
using Microsoft.AspNetCore.Http;

namespace AplicacaoWeb.Controllers
{
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Login(int? id)
        {
            //Para realizar o logout
            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
            }
            //Fim
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool loginOk = login.ValidarLogin();
                if (loginOk)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "E-mail ou Senha são inválidos!";
                }
            }   
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
