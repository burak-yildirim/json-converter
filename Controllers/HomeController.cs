using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConvertJson.Models;
using ConvertJson.Exceptions;

namespace ConvertJson.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        throw new UserFriendlyException("Not Found!", new NotImplementedException())
        {
            StatusCode = 404
        };
    }

    public IActionResult Privacy()
    {
        throw new UserFriendlyException("Not Found!", new NotImplementedException())
        {
            StatusCode = 404
        };
    }
}
