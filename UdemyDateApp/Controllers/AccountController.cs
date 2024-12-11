using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UdemyDateApi.Data;
using UdemyDateApi.Dtos;
using UdemyDateApi.Interfaces;
using UdemyDateApp.Entities;

namespace UdemyDateApi.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

     
        [HttpPost("Login")]


        public async Task<ActionResult<UserDto>> Login([FromBody]LoginDto userDto)
        {   var user = await context.Users.SingleOrDefaultAsync(x => x.Name == userDto.name);
            if (user == null) return Unauthorized("invalid userName");
            using var hmac = new HMACSHA512(user.PassSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PassHash[i]) return Unauthorized("invalid password");
            }
            return new UserDto
            {
                UserName = userDto.name,
                Token = tokenService.CreateToken(user)

            };

        }
        [HttpPost("Register")]

   
        public async Task<ActionResult<UserDto>> Register(RegisterDto userDto)
        {
            if (await UserExists(userDto.UserName))
                return BadRequest("UserName is Taken");
            using var hmac = new HMACSHA512();
            var user = new AppUser()
            {
                Name = userDto.UserName.ToLower(),
                PassHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.UserPassword)),
                PassSalt = hmac.Key
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return new UserDto
            {
                UserName = userDto.UserName,
                Token = tokenService.CreateToken(user)

            };
        }


        private async Task<bool> UserExists(string userName)
        {
            return await context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }
    }
}
