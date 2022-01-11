using MvcCoreCrudDepartamentosEF.Data;
using MvcCoreCrudDepartamentosEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreCrudDepartamentosEF.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;
        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public List<Empleado> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados select datos;
            return consulta.ToList();
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        //consulta para devolver los empleados por oficio
        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        //consulta para modificar el salario de los empleados por oficio
        public void IncrementarSalarioEmpleados(string oficio, int incremento)
        {
            //buscar los empleados a modificar
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            //debemos recorrer todos los empleados y modificar el salario de forma individual
            foreach (Empleado emp in empleados)
            {
                emp.Salario += incremento;
            }
            this.context.SaveChanges();
        }
    }
}
