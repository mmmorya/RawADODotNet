using Microsoft.AspNetCore.Mvc;
using Project.InfraStructure.Contracts.Business;
using RawADODotNet.Web.ViewModel;

namespace RawADODotNet.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeManager _employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public IActionResult Index()
        {
            var result = _employeeManager.Get();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Detail(int Id)
        {
            var result = _employeeManager.Get(Id);
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeManager.CreateEmployee(employeeVM.ToDto());
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var result = _employeeManager.Get(Id);
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeManager.Edit(employeeVM.ToDto());
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var result = _employeeManager.Get(Id);
            return View(result.Data);
        }

        [HttpPost("Employee/Delete/{Id}")]
        public IActionResult DeleteConfirmed(int Id)
        {
            if (ModelState.IsValid)
            {
                var result = _employeeManager.Delete(Id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

