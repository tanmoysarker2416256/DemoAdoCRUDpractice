using DemoAdoCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAdoCrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDataAccessLayerWithSP _dataAccessLayer;
        public EmployeeController()
        {
            _dataAccessLayer = new EmployeeDataAccessLayerWithSP();
        }
        public IActionResult Index()
        {
           var employee =  _dataAccessLayer.GetEmployees();

            return View(employee);
        }
        public IActionResult Create()
        {
          

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee )
        {

            if (ModelState.IsValid)
            {
                _dataAccessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }

        }

        public IActionResult Details(int id )
        {
            var employee = _dataAccessLayer.GetDetails(id);
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _dataAccessLayer.GetDetails(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _dataAccessLayer.UpdateEmployee(employee);

                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public IActionResult Delete(int id)
        {
            var employee = _dataAccessLayer.GetDetails(id);
            return View(employee);
        }
        public IActionResult DeleteData(int id)
        {
            _dataAccessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
