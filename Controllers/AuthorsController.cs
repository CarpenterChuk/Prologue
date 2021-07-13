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
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorViewModel author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
    }
}
