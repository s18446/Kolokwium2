using Kolokwium2.Exceptions;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("api/championships/{id:int}/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IChampionshipsDbService _service;

        public TeamsController(IChampionshipsDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetTeams(int id)
        {
            try
            {
                var result = _service.GetChampionships(id);
                return Ok(result);
            }catch(ChampionshipDoesNotExistException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}
