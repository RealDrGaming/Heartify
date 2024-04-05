using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Heartify.Core.Constants.AdministratorConstants;

namespace Heartify.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}