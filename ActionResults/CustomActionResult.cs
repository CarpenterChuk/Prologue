using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prologue.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prologue.ActionResults
{
    public class CustomActionResult: IActionResult
    {
        private readonly CustomActionResultViewModel _result;

        public CustomActionResult(CustomActionResultViewModel result)
        {
            _result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_result.Exception ?? _result.Publisher as object)
            {
                StatusCode = _result.Exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
