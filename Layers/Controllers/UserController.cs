using System.Threading.Tasks;
using Layers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Layers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> List()
        {
            var users = userService.ListAll();
            return View(users);
        }

    }
}