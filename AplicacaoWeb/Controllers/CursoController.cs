using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicacaoWeb.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace AplicacaoWeb.Controllers
{
    public class CursoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListarCursos = new Curso().ListarTodosCursos();
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                //Carregar o registro do curso numa viewBag
                ViewBag.Curso = new Curso().RetornarCurso(id);
            }
            else
            {
                ViewBag.ListarIntituicoes = new Curso().RetornarListaInstituicoes(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Curso curso)
        {
            if (ModelState.IsValid)
            {
                curso.Gravar();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirCurso(int id)
        {
            new Curso().Excluir(id);
            return View();
        }
    }
}
