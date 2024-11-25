using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SellingWebsite.Controllers
{
    [Authorize]
    public class BaseController : Controller

    {

    }
}
