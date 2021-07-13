using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prologue.Data.Services;
using Prologue.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prologue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PablishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PablishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherViewModel publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }
    }
}
