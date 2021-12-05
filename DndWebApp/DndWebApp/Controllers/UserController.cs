using Dnd.Dal.Dto;
using Dnd.Dal.Entities;
using Dnd.Dal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DndWebApp.Controllers
{
    [Route("user")]

    public class UserController : Controller
    {
        private UserService userService;
        public UserController()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<DndContext>();
            contextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dnd;Trusted_Connection=True;MultipleActiveResultSets=true");
            userService = new UserService(new DndContext(contextOptionsBuilder.Options));
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ApplicationUserHeader> GetUser(string name)
        {
            var user = userService.FindUserByName(name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{name}/addfriend/{friend}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddFriend(string name, string friend)
        {
            var success = userService.AddFriend(name, friend);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
