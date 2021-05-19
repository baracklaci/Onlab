using Dnd.Dal.Entities;
using Dnd.Dal.Services;
using DndWebApp.Controllers.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DndWebApp.Controllers
{
    [EnableCors("AllowAny")]
    [ApiController]

    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserService userService;
        private readonly TokenService tokenService;

        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            var contextOptionsBuilder = new DbContextOptionsBuilder<DndContext>();
            contextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dnd;Trusted_Connection=True;MultipleActiveResultSets=true");
            this.userService = new UserService(new DndContext(contextOptionsBuilder.Options));
            this.tokenService = new TokenService();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Token>> Login([FromBody] UsernamePw value)
        {
            var user = userService.GetEntityUser(value.UserName);
            if (user == null)
                return BadRequest("No user found");
            var result = await signInManager.CheckPasswordSignInAsync(user, value.Password, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                
                return Ok(new Token{ token = tokenService.getToken() });
            }

            return Unauthorized();
        }


        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Token>> Register([FromBody] Register value)
        {
            var user = new ApplicationUser { UserName = value.UserName, Email = value.Email };
            var result = await userManager.CreateAsync(user, value.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new Token { token = tokenService.getToken() });
            }

            return Conflict();
        }


    }
}
