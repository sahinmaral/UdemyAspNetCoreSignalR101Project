using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.Entity.Concrete;
using SignalR.Web.ViewModels.User;

namespace SignalR.Web.Controllers;

public class AuthController  : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public AuthController(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
    {
        User user = _mapper.Map<User>(viewModel);
        var identityResult = await _userManager.CreateAsync(user, viewModel.Password);
        if (identityResult.Succeeded)
        {
            return Redirect("/Auth/Login");
        }
        
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginUserViewModel viewModel)
    {
        var identityResult = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, true, false);
        if (identityResult.Succeeded)
        {
            return Redirect("/");
        }

        return View();
    }
}