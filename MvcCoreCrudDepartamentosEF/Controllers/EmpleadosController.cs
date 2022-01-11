using Microsoft.AspNetCore.Mvc;
using MvcCoreCrudDepartamentosEF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;
        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
