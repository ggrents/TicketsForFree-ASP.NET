using Microsoft.AspNetCore.Mvc;
using TicketsForFree.Models;
using TicketsForFree.Services;


namespace TicketsForFree.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet]

       
       public async Task<ActionResult<IEnumerable<User>>> GetAll() { 
       
          var users = await _userService.GetAll();
          return Ok(users);
       }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.Get(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User newUser)
        {
            try
            { 
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);


                newUser.PasswordHash = hashedPassword;
                


                var createdUser = await _userService.CreateUser(newUser);


                return Ok(newUser);

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "Failed to create user", error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("{id}")]


        public  async Task<ActionResult> DeleteUser(int id)
        {
           await _userService.DeleteUser(id);

            return Ok();
        }
    }
}
