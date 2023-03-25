using Microsoft.AspNetCore.Mvc;
using Project.InfraStructure.Contracts.Business;
using Project.InfraStructure.Models.RequestModel;
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
        public IActionResult Index(int page, string searchTerm, int pageSize = 10)
        {
            var result = _employeeManager.Get(new CommonRequestModel() { 
                PageNumber = page == 0 ? 1 : page,
                PageSize = pageSize,
                SearchTerm = searchTerm
            });
            #region ViewBags
            ViewBag.CurrentPage = page == 0 ? 1 : page;
            ViewBag.TotalItemCount = result.TotalRecords;
            ViewBag.PageCount = (int)Math.Ceiling((double)result.TotalRecords / pageSize);
            ViewBag.SearchTerm = searchTerm;
            ViewBag.PageSize = pageSize;
            #endregion

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

