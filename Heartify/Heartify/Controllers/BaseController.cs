using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Heartify.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}