using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectLibrary.Controllers
{
    public class ProbnyController : Controller
    {
        [Authorize]
        public IActionResult Admin()
        {
            ViewBag.Mess = "Po zalogowaniu bedzie widoczne";
            return View();
        }
        [AllowAnonymous]
        public IActionResult Gosc()
        {
            return View();
        }
    }
}
