using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Db;
using CA.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public RegisterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            // 添加用户到数据库
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Registration successful" });
        }
    }
}

