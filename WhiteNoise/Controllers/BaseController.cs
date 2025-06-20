using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WhiteNoise.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {

    }
}
