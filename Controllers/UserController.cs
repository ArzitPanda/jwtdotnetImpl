

using Microsoft.AspNetCore.Mvc;

namespace learnApi.Controllers;

[ApiController]
[Route("user")]
public class UserController:ControllerBase
{
    [HttpGet]
    public string getName()
    {
        return "name test";
    }


}