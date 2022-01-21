using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Web.Common;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
}