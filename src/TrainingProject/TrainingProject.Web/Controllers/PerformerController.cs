using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingProject.Data.Models;

namespace TrainingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        AppContext _appContext;
        public PerformerController(AppContext context)
        {
            _appContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Performer>>> GetPerformers()
        {
            return await _appContext.Performers.ToListAsync();
        }
    }
}