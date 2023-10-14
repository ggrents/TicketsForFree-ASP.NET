using Microsoft.AspNetCore.Mvc;
using TicketsForFree.Models;
using TicketsForFree.Services;
using TicketsForFree.ViewModels;


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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel newUser)
        {
            try
            { 
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.Password);


                var UserToCreate = new User
                {

                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    PasswordHash = hashedPassword
                };

                
                
                var createdUser = await _userService.CreateUser(UserToCreate);


                return Ok(createdUser);

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
            var users = await _userService.GetAll();
            return Ok(users);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserViewModel updatedUser)
        {
            try
            {
                if (updatedUser == null)
                {
                    return BadRequest(new { message = "User data is invalid" });
                }

      
                var existingUser = await _userService.Get(id);

                if (existingUser == null)
                {
                    return NotFound(new { message = "User not found" });
                }


                existingUser.FirstName = updatedUser.FirstName;
                existingUser.LastName = updatedUser.LastName;
                existingUser.Email = updatedUser.Email;




                var UserToUpdate = await _userService.UpdateUser(id, existingUser);

                return Ok(UserToUpdate);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to update user", error = ex.Message });
            }


            
        }


        [HttpPatch("{id}")]

        public async Task<ActionResult> PartUpdateUser(int id, [FromBody] UpdateUserViewModel updatedUser)
        {
            try
            {
                if (updatedUser == null)
                {
                    return BadRequest(new { message = "User data is invalid" });
                }


                var existingUser = await _userService.Get(id);

                if (existingUser == null)
                {
                    return NotFound(new { message = "User not found" });
                }


                if (updatedUser.FirstName != null)
                {
                    existingUser.FirstName = updatedUser.FirstName;
                }

                if (updatedUser.LastName != null)
                {
                    existingUser.LastName = updatedUser.LastName;
                }

                if (updatedUser.Email != null)
                {
                    existingUser.Email = updatedUser.Email;
                }



                var UserToUpdate = await _userService.UpdateUser(id, existingUser);

                var user = await _userService.Get(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Failed to update user", error = ex.Message });
            }
        }
    }
}
