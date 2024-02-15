using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeartifyDating.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}