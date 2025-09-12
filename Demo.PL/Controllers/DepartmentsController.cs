using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers;

public class DepartmentsController : Controller
{
    private IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public IActionResult Index()
    {
        //Get All Departments
        return View();
    }
}
