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
            return View("Index", new RegisterViewModel());
        }

        [HttpPost]
        [Route("/authontication")]
        public IActionResult IndexSave(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                authBL.GetUser(Mapp.AuthMapper.MapRegisterViewModelToUserModel(model));
                return Redirect("/");
            }

            return View("Index", model);
        }

    }
}
