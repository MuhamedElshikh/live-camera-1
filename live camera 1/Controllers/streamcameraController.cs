using Microsoft.AspNetCore.Mvc;

namespace live_camera_1.Controllers
{
    public class streamcameraController : Controller
    {
        public IActionResult cam()
        {
            return View();
        }
    }
}
