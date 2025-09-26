using AutoMapper;
using Demo.BLL.Services;
using Demo.BLL.Services.DataTransferObjects.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger, IWebHostEnvironment env
        , IMapper mapper) :
    Controller
    {
        private IEmployeeService _employeeService = employeeService;

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();
            //ViewBag.Message = "Message from Employees Controller Index";
            return View(employees);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }


            try
            {
                var result = _employeeService.Add(request);

                if (result > 0)
                    TempData["Message"] = $"Employee {request.Name} Created";
                else
                    TempData["Message"] = $"Cant Create Employee {request.Name}";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Something went wrong");
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetByID(id.Value);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetByID(id.Value);
            if (employee == null)
                return NotFound();
            return View(mapper.Map<EmployeeUpdateRequest>(employee));
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeUpdateRequest request)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != request.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(request);
            try
            {
                var result = _employeeService.Update(request);
                if (result > 0)
                    return RedirectToAction("Index");
                ModelState.AddModelError(string.Empty, "Something went wrong");
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Something went wrong");
            }
            return View(request);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetByID(id.Value);
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetByID(id.Value);
            try
            {
                var isDeleted = _employeeService.Delete(id.Value);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Something went wrong");
            }
            catch (Exception ex)
            {
                if (env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    ModelState.AddModelError(string.Empty, "Something went wrong");
            }
            return View(employee);
        }
    }
}
