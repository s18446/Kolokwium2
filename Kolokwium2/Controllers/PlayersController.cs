using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Controllers
{
    [Route("api/teams/{id:int}/players")]
    public class PlayersController : ControllerBase
    {

        [HttpPut]
        IActionResult AddPlayer(int id)
        {

            return Ok();
        }




    }
}
