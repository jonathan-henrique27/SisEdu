using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AplicacaoWeb.Models.Model;


namespace AplicacaoWeb.Controllers
{
    public class EmpresasController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaEmpresas = new Empresa().ListarTodasEmpresas();
            return View();
        }
    }
}
