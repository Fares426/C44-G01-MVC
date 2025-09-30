using Demo.BLL.Services;
using Demo.BLL.Services.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers;

public class DepartmentsController(IDepartmentService departmentService, IWebHostEnvironment env) :
    Controller
{
    private IDepartmentService _departmentService = departmentService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllAsync();
        return View(departments);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(DepartmentRequest request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }


        try
        {
            var result = await _departmentService.AddAsync(request);

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
    public async Task<IActionResult> Details(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = await _departmentService.GetByIdAsync(id.Value);
        if (department == null)
            return NotFound();
        return View(department);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = await _departmentService.GetByIdAsync(id.Value);
        if (department == null)
            return NotFound();
        return View(department.ToUpdateRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute] int? id, DepartmentUpdateRequest request)
    {
        if (!id.HasValue)
            return BadRequest();

        if (id.Value != request.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(request);
        try
        {
            var result = await _departmentService.UpdateAsync(request);
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
    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = await _departmentService.GetByIdAsync(id.Value);
        if (department == null)
            return NotFound();
        return View(department);
    }

    [HttpPost, ActionName("DeleteAsync")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if (!id.HasValue)
            return BadRequest();
        var department = await _departmentService.GetByIdAsync(id.Value);
        try
        {
            var isDeleted = await _departmentService.DeleteAsync(id.Value);
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
