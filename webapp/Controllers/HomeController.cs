using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;
namespace webapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Calculator(string op, double? a, double? b)
    {
        //var op:StringValues = Request.Query["op"];
        //var a:StringValues = Request.Query["a"];
        //var b:StringValues = Request.Query["b"];
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby";
            return View("CustomError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator";
            return View("CustomError");
        }
        ViewBag.A = a;
        ViewBag.B = b;
        switch(op)

        {
            case "add":
                ViewBag.Result = a + b;
                ViewBag.Operator = "+";
                break;
            case "sub":
                ViewBag.Result = a - b;
                ViewBag.Operator = "-";
                break;
            case "div":
                ViewBag.Result = a / b;
                ViewBag.Operator = ":";
                break;
            case "mul":
                ViewBag.Result = a * b;
                break;
        }
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public enum Operator
    {
        Add, Sub, Mul, Div
    }
}