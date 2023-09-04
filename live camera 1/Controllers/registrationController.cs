using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using live_camera_1.Models.DB; // Make sure this is the correct namespace for your UserRegistration class

namespace live_camera_1.Controllers
{
    [Route("registration")]
    public class registrationController : Controller
    {
        private readonly UserManager<UserRegistration> _userManager;
        private readonly SignInManager<UserRegistration> _signInManager;

        public registrationController(
            UserManager<UserRegistration> userManager,
            SignInManager<UserRegistration> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("register")] // Change the route name for the GET action
        public IActionResult registration()
        {
            return View();
        }

        [HttpPost]
        [Route("register")] // Change the route name for the POST action
        public async Task<IActionResult> registration(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserRegistration
                {
                    Username = model.Username,
                    Email = model.Email,
                    Confirmpwd = model.Confirmpwd,
                    Gender = model.Gender,
                    MaritalStatus = model.MaritalStatus,
                    Pwd = model.Pwd
                };
                var result = await _userManager.CreateAsync(user, model.Pwd);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("login", "login"); // Redirect to a success page
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
