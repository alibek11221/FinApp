using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinAppDataManger.Library.DataAccess;
using FinAppDataManger.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FinAppApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransitionController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TransitionController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public void PostTransition(TransitionModel transition)
        {
            TransitionData data = new TransitionData(_config);
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            data.MakeTransition(transition, userid);
        }
    }
}