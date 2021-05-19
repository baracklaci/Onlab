using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Dnd.Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dnd.Dal.Entities;
using Dnd.Dal.Dto;
using Microsoft.AspNetCore.Authorization;

namespace DndWebApp.Controllers
{
    [ApiController]

    [Route("user")]
    public class SheetController : ControllerBase
    {
        private SheetService sheetService;
        public SheetController()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<DndContext>();
            contextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dnd;Trusted_Connection=True;MultipleActiveResultSets=true");
            sheetService = new SheetService(new DndContext(contextOptionsBuilder.Options));
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{username}/sheets")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<string>> GetSheets(string username)
        {
            var sheet = sheetService.AllSheetByName(username);
            if (sheet == null)
            {
                return NotFound();
            }
            return Ok(sheet);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{username}/sheet/{sheetname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dnd.Dal.Dto.CharacterSheet> GetSheet(string username, string sheetname)
        {
            var sheet = sheetService.FindSheetByName(username, sheetname);
            if (sheet == null)
            {
                return NotFound();
            }
            return Ok(sheet);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{username}/sheet/{sheetname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<string>> UpdateSheet(string username, string sheetname,[FromBody] Dnd.Dal.Dto.CharacterSheet sheet)
        {
            var success = sheetService.UpdateSheet(username, sheetname, sheet);
            if (!success)
            {
                return NotFound();
            }
            return Ok(sheet);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{username}/newsheet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dnd.Dal.Entities.CharacterSheet> NewSheet(string username, [FromBody] Dnd.Dal.Dto.CharacterSheet sheet)
        {
            Console.WriteLine("new");
            var result = sheetService.AddCharacterSheet(username, sheet);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(sheet);
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("{username}/sheet/{sheetname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<string>> DeleteSheet(string username, string sheetname)
        {
            var success = sheetService.DeleteCharacterSheet(username, sheetname);
            if (!success)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
