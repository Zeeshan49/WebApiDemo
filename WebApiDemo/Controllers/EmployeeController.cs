using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        public IHttpActionResult GetAllEmployees()
        {
            IList<EmployeeViewModel> Employees = null;

            using (var ctx = new EmployeeEntities())
            {
                Employees = ctx.employees.Include("EmployeeAddress")
                            .Select(e => new EmployeeViewModel()
                            {
                                Id = e.ID,
                                FirstName = e.FirstName,
                                LastName = e.LastName
                            }).ToList<EmployeeViewModel>();
            }

            if (Employees.Count == 0)
            {
                return NotFound();
            }

            return Ok(Employees);
        }
    }
}
