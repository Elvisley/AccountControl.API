using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AC.Domain;
using AC.StatusApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Controllers
{
    [Route("api/1.0/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Status>> Get([FromServices] StatusApplication statusApplication)
        {
            return statusApplication.GetAll().ToList();
        }
    }
}