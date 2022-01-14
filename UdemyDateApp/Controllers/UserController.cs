using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDateApp.Data;
using UdemyDateApp.Entities;

namespace UdemyDateApp.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _dataConext;

        public UserController(DataContext dataConext)
        {
            _dataConext = dataConext;
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _dataConext.Users.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task< ActionResult<AppUser>> GetUser(int id)
        {
            return await _dataConext.Users.FindAsync(id);
        }
    }
}
