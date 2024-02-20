using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Heartify.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}