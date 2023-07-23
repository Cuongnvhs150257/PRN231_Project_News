using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project_API.DTO;
using Project_API.Models;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private PRN_ProjectContext _context;

        public UserController(PRN_ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetUserById/{userId}")]
        public async Task<User> GetUserById(int userId)
        {
            var existuser = _context.Users.FirstOrDefault(x => x.UserId == userId);

            return existuser;

        }


        [HttpGet("GetUserById/{username}/{password}")]
        public async Task<ActionResult<User>> Login( string username, string password)
        {
            try
            {
                var existuser = _context.Users.FirstOrDefault(x => x.Username.EndsWith(username));

                if (existuser == null)
                {
                    return NotFound("Does not have acc!");
                }
                var success = _context.Users.FirstOrDefault(x => x.Password.EndsWith(password));

                if (success == null)
                {
                    return NotFound("Password is not correct!");
                }

                return Ok(existuser);

            }
            catch(Exception ex)
            {
                return Conflict(ex);

            }

        }

        [HttpPost("CreateUser")]
        public IActionResult CreateNewUser(UserDTO user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest();
                }
                var newuser = new User
                {
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email, 
                    Role = user.Role,
                    Description = user.Description,
                    Img = user.Img
                };
                _context.Users.Add(newuser);
                var rowAffected = _context.SaveChanges();
                return Ok(rowAffected);

            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }

            
        }

        [HttpPut("{userId}")]
        public IActionResult EditUser(int userId, UserDTO user)
        {
            try
            {
                var existuser = _context.Users.FirstOrDefault(x => x.UserId == userId);
                if(existuser == null || user == null)
                {
                    return NotFound("Does not have account! Plz create new account!");
                }

                existuser.Username = user.Username;
                existuser.Password = user.Password;
                existuser.Email = user.Email;
                existuser.Role = user.Role;
                existuser.Description = user.Description;
                existuser.Img = user.Img;

                 _context.Users.Update(existuser);
                var rowAffected = _context.SaveChanges();
                return Ok(rowAffected);

            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DleteteUser(int userId)
        {
            try
            {
                var existuser = _context.Users.FirstOrDefault(x => x.UserId == userId);
                if (existuser == null)
                {
                    return NotFound("Does not have account! Plz create new account!");
                }
                _context.Users.Remove(existuser);
                var rowAffected = _context.SaveChanges();
                return Ok(rowAffected);

            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
}
