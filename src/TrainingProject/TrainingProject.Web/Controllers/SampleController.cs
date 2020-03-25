using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TrainingProject.Domain.Logic.Interfaces;

namespace TrainingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly IUserTypeManager _userTypeManager;

        public SampleController(IUserTypeManager userTypeManager)
        {
            _userTypeManager = userTypeManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] string search,
            [FromQuery] int? fromIndex = default,
            [FromQuery] int? toIndex = default,
            CancellationToken cancellationToken = default)
        {
            var result = await _userTypeManager.GetUserTypesAsync(cancellationToken);
            return Ok(result);
        }
    }
}
