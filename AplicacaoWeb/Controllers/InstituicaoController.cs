using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoWeb.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWeb.Controllers
{
    public class InstituicaoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListarInstituicoes = new Instituicao().ListarTodasInstituicoes();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar o registro da instituicao numa viewBag
                ViewBag.Instituicao = new Instituicao().RetornarInstituicao(id);
            }
            else 
            {
                ViewBag.ListarEmpresas = new Instituicao().RetornarListaEmpresas();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                instituicao.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirInstituicao(int id)
        {
            new Instituicao().Excluir(id);
            return View();
        }
    }
}
