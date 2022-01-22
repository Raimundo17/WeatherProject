using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeatherProject.Data;
using WeatherProject.Data.Entities;
using WeatherProject.Helpers;

namespace WeatherProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public UserController(IUserHelper userHelper, UserManager<User> userManager, DataContext context)
        {
            _userHelper = userHelper;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            return await _userHelper.GetUserByEmailAsync(email); 
        }

        [HttpGet]
        [Route("{email}/{password}")]
        public async Task<bool> CheckUserExists(string email, string password)
        {
            return await _userHelper.CheckUserAndPassword(email, password);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
    }
}
