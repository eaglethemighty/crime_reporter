using Microsoft.AspNetCore.Mvc;

namespace CrimeService.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public ActionResult ExceptionPage()
        {
            return Problem();
        }
    }
}
