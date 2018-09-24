using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AC.Domain;
using AC.PersonApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Controllers
{
    [Route("api/1.0/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet("legal")]
        public ActionResult<IEnumerable<PersonLegal>> GellAllPersonLegal([FromServices] PersonApplication personApplication)
        {
            return personApplication.GetAllPersonLegal().ToList();
        }

        [HttpGet("physical")]
        public ActionResult<IEnumerable<PersonPhysical>> GetAllPersonPhysical([FromServices] PersonApplication personApplication)
        {
            return personApplication.GetAllPersonPhysical().ToList();
        }

        [HttpPost("legal")]
        public ActionResult<PersonLegal> PostPersonLegal(PersonLegal person, [FromServices] PersonApplication personApplication)
        {
            try
            {
                return personApplication.PostPersonLegal(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }

        [HttpPost("physical")]
        public ActionResult<PersonPhysical> PostPersonPhysical(PersonPhysical person, [FromServices] PersonApplication personApplication)
        {
            try
            {
                return personApplication.PostPersonPhysical(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}