using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDateApi.Data;
using UdemyDateApp.Entities;

namespace UdemyDateApi.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly DataContext _dataConext;

        public UserController(DataContext dataConext)
        {
            _dataConext = dataConext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _dataConext.Users.ToListAsync();
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _dataConext.Users.FindAsync(id);
        }
    }
}
