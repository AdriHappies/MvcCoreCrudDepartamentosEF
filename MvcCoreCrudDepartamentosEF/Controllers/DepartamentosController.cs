using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentosEF.Models;
using MvcCoreCrudDepartamentosEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }
        public IActionResult Details(int id)
        {
            Departamento departamento = this.repo.FindDepartamento(id);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Departamento departamento)
        {
            this.repo.InsertarDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            this.repo.EliminarDepartamento(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Departamento dept = this.repo.FindDepartamento(id);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Edit(Departamento departamento)
        {
            this.repo.ModificarDepartamento(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }
    }
}
