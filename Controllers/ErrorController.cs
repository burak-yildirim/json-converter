using ConvertJson.Exceptions;
using ConvertJson.Extensions;
using ConvertJson.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ConvertJson.Controllers;

public class ErrorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebHostEnvironment _webEnvironment;

    public ErrorController(ILogger<HomeController> logger, IWebHostEnvironment webEnvironment)
    {
        _logger = logger;
        _webEnvironment = webEnvironment;
    }

    public IActionResult Index()
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;

        if(exception != null)
            _logger.LogError(exception, exception.ToString());

        var userFriendlyMessage = "There seems to be a problem ..";
        var statusCode = Response.StatusCode >= 400 ? Response.StatusCode : 400;
        if (exception is UserFriendlyException ex)
        {
            userFriendlyMessage = ex.Message;
            statusCode = ex.StatusCode;
        }

        Response.StatusCode = statusCode;
        return View(new ErrorViewModel()
        {
            IsDevelopment = _webEnvironment.IsDevelopment(),
            ErrorMessage = userFriendlyMessage,
            Exception = exception,
            StatusCode = Response.StatusCode
        });
    }

    public IActionResult Development()
    {
        var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = exceptionHandlerFeature?.Error;

        if(exception != null)
            _logger.LogError(exception, exception.ToString());

        Response.StatusCode = exception is UserFriendlyException ex 
            ? ex.StatusCode
            : Response.StatusCode >= 400 
            ? Response.StatusCode 
            : 400;
        return View(new ErrorViewModel()
        {
            IsDevelopment = _webEnvironment.IsDevelopment(),
            ErrorMessage = exception?.Message,
            Exception = exception,
            StatusCode = Response.StatusCode
        });
    }
}