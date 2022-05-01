using Microsoft.AspNetCore.Mvc;

namespace soitic.Controllers;

// [ApiController]
[Route("")]
public class SPAController : ControllerBase
{
    [HttpGet("")]
    [HttpGet("{file}")]
    [HttpGet("{folder1}/{file}")]
    [HttpGet("{param1}/{param2}/{param3}")]
    [HttpGet("{param1}/{param2}/{param3}/{param4}")]
    public IActionResult GetSPA(string folder1, string file)
    {
        if (folder1 == "js")
            return File($"~/{folder1}/{file}", "text/javascript");
        else if (folder1 == "css")
            return File($"~/{folder1}/{file}", "text/css");
        else if (file == "favicon.ico")
            return File($"~/{file}", "text/image");
        return File("~/index.html", "text/html");
    }
}
