using Microsoft.AspNetCore.Mvc;

namespace MovieTicket.WebApi.Controller;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}