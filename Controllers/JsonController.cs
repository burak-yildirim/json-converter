using ConvertJson.Extensions;
using ConvertJson.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConvertJson.Controllers;

public class JsonController : Controller
{
    
    private readonly ILogger<HomeController> _logger;
    private readonly IJsonConverterService _jsonConverterService;

    public JsonController(ILogger<HomeController> logger, IJsonConverterService jsonConverterService)
    {
        _logger = logger;
        _jsonConverterService = jsonConverterService;
    }

    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Expects json as request body and tries to convert it to xml.
    /// To get request body, "[FromBody] object requestBody" could be used too but
    /// then if the json is invalid, we would get a null object. Instead StreamReader
    /// is used to get body as string, so it could be logged even if the body is not
    /// valid json.
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> ToXml()
    {
        var reqBodyStr = await Request.GetBodyAsString();
        _logger.LogInformation($"input:\n{reqBodyStr}");

        var xmlStr = await _jsonConverterService.ToXmlStr(reqBodyStr);
        _logger.LogInformation($"output:\n{xmlStr}");
        
        return Ok(xmlStr);
    }
}
