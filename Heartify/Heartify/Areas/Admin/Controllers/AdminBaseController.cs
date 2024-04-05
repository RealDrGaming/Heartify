using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Heartify.Core.Constants.RoleConstants;

namespace Heartify.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}