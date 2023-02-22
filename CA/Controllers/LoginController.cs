using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Db;
using CA.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userFromDb == null)
            {
                return NotFound("wrong password or username");
            }

            if (userFromDb.Password == user.Password)
            {
                return Ok("Success");
            }
            else
            {
                return BadRequest("wrong password or username");
            }
        }
    }
}

