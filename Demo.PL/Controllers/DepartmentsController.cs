using Demo.BLL.Services;
using Demo.BLL.Services.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers;

public class DepartmentsController(IDepartmentService departmentService, ILogger<DepartmentsController> logger, IWebHostEnvironment env) :
    Controller
{
    private IDepartmentService _departmentService = departmentService;

    [HttpGet]
    public IActionResult Index()
    {
        var departments = _departmentService.GetAll();
        return View(departments);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(DepartmentRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }


        try
        {
            var result = _departmentService.Add(request);

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
    public IActionResult Details(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = _departmentService.GetById(id.Value);
        if (department == null)
            return NotFound();
        return View(department);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = _departmentService.GetById(id.Value);
        if (department == null)
            return NotFound();
        return View(department.ToUpdateRequest());
    }

    [HttpPost]
    public IActionResult Edit([FromRoute] int? id, DepartmentUpdateRequest request)
    {
        if (!id.HasValue)
            return BadRequest();

        if (id.Value != request.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(request);
        try
        {
            var result = _departmentService.Update(request);
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
        var department = _departmentService.GetById(id.Value);
        if (department == null)
            return NotFound();
        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = _departmentService.GetById(id.Value);
        try
        {
            var isDeleted = _departmentService.Delete(id.Value);
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
        return View(department);
    }

}
