using Microsoft.AspNetCore.Mvc;
using MvcCrudOperation.Models;
using MvcCrudOperation.RepositoryLayer;

namespace MvcCrudOperation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRL _employeeRL;
        public EmployeeController(IEmployeeRL employeeRL) 
        {
            _employeeRL = employeeRL;
        }

        public IActionResult Index()
        {
            var employee = _employeeRL.GetList();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddEmployeeViewModel request)
        {
            _employeeRL.Add(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult View(Guid Id) 
        {
            var employee = _employeeRL.GetById(Id);
            if (employee != null) 
            {
                return  View("View", employee);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult View(Employee request)
        {
            var employee = _employeeRL.GetById(request.Id);
            if (employee != null)
            {
                _employeeRL.Edit(employee, request);

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Employee request)
        {
            var employee = _employeeRL.GetById(request.Id);
            if (employee != null)
            {
                _employeeRL.Delete(employee);

            }
            return RedirectToAction("Index");
        }
    }
}
