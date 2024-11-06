using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using soelaketc.Data;
using soelaketc.Entities;

namespace soelaketc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is null)
                return NotFound("User with ID: '" + id + "' is not found.");

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            var updatedUser = await _context.Users.FindAsync(user.Id);

            if (updatedUser is null)
                return NotFound("User with ID: '" + user.Id + "' is not found.");

            updatedUser.Email = user.Email;
            updatedUser.Name = user.Name;
            updatedUser.Password = user.Password;
            updatedUser.PhoneNumber = user.PhoneNumber;
            await _context.SaveChangesAsync();

            return Ok(updatedUser);
        }

        [HttpDelete]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var deletedUser = await _context.Users.FindAsync(id);

            if (deletedUser is null)
                return NotFound("User with ID: '" + id + "' is not found.");

            _context.Users.Remove(deletedUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }
}
