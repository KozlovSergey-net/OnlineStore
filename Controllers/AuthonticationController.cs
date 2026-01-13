using Microsoft.AspNetCore.Mvc;
using OnlineStore.BL;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class AuthonticationController : Controller
    {
        private readonly IAuthBL authBL;
        public AuthonticationController(IAuthBL authBL)
        {
            this.authBL = authBL;
        }
        [HttpGet]
        [Route("/authontication")]
        public IActionResult Index()
        {
            return View("Index", new AuthViewModel());
        }

        [HttpPost]
        [Route("/authontication")]
        public async Task<IActionResult> IndexSave(AuthViewModel model)
        {
            if (ModelState.IsValid)
            {
                await authBL.GetUser(model.Email!, model.Password!);
                return Redirect("/");
            }

            return View("Index", model);
        }

    }
}
