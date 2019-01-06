using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chatter.Server.Services;
using Chatter.Server.Models;

namespace Chatter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var mongoDbService = new MongoDbService("mongodb://andrei:qaz12wsx@ds149754.mlab.com:49754/chatter", "chatter", "users");
            var users = await mongoDbService.GetAllUsers();
            return Json(users);
        }

        [HttpPost]
        public async Task Post([FromBody]UserModel model)
        {
            var mongoDbService = new MongoDbService("mongodb://andrei:qaz12wsx@ds149754.mlab.com:49754/chatter", "chatter", "users");
            await mongoDbService.InserUserAsync(model);
        }
    }
}
