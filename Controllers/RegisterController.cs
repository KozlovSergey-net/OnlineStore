using Microsoft.AspNetCore.Mvc;
using OnlineStore.BL;
using OnlineStore.DAL;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthBL authBL;
        public RegisterController(IAuthBL authBL)
        {
            this.authBL = authBL;
        }
        [HttpGet]
        [Route("/register")]
        public IActionResult Index()
        {
            return View("Index", new RegisterViewModel());
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult IndexSave(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                authBL.CreateUser(Mapp.AuthMapper.MapRegisterViewModelToUserModel(model));
                return Redirect("/");
            }

            return View("Index", model);
        }
    }
}
