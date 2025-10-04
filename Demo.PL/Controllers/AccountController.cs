using Demo.DAL.Entities;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers;

public class AccountController(UserManager<ApplicationsUser> userManager, SignInManager<ApplicationsUser> signInManager)
    : Controller
{
    [Authorize]
    #region Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View();

        var user = new ApplicationsUser
        {
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.UserName
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
            return RedirectToAction("Login");

        foreach (var error in result.Errors)
            ModelState.AddModelError(string.Empty, error.Description);

        return View(model);
    }
    #endregion

    #region Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await userManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            if (await userManager.CheckPasswordAsync(user, model.Password))
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError(string.Empty, "Invalid Email or Password");
        return View(model);
    }
    #endregion

    #region LogOut
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
    #endregion
}
// Authentication 
// Who are you ?
// email , password 
// External Login => Google , Facebook , Twitter
// Cookie based Auth
// API Key
// JWT Token based Auth
// Token => encrypted string => Email , Password , Expiration Time , Id , Roles , Claims
// Decryption + Token => User
//Password + Hashing => Hashed Password
// Authorization
// What are you allowed to do ? 
// Role Based Auth
// Permission Based Auth || Policy Based Auth
// Domain Models for security Module
// User , Role , UserRoles , UserClaims ,  RoleClaims , UserLogins , UserTokens