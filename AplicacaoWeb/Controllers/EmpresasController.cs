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
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar o registro do cliente numa viewBag
                ViewBag.Empresa = new Empresa().RetornarEmpresa(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                empresa.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirEmpresa(int id)
        {
            new Empresa().Excluir(id);
            return View();
        }
    }
}
    
