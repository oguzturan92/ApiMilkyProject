using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Milky.Entity.Concrete;
using MilkyProject.Business.Abstract;

namespace MilkyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _teamService.GetListAll();
            return Ok(values);
        }

        [HttpGet("TeamGet")]
        public IActionResult TeamGet(int id)
        {
            var value = _teamService.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult TeamCreate(Team team)
        {
            _teamService.Insert(team);
            return Ok();
        }

        [HttpPut]
        public IActionResult TeamUpdate(Team team)
        {
            _teamService.Update(team);
            return Ok();
        }

        [HttpDelete]
        public IActionResult TeamDelete(int id)
        {
            _teamService.Delete(id);
            return Ok();
        }

        [HttpGet("GetTeamsListAndSocials")]
        public IActionResult GetTeamsListAndSocials()
        {
            var values = _teamService.GetTeamsListAndSocials();
            return Ok(values);
        }

    }
}