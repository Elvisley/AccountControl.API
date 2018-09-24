using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AC.TransactionTypeApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Controllers
{
    [Route("api/1.0/transaction_type")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get([FromServices] TransactionTypeApplication transactionTypeApplication)
        {
            return Ok(transactionTypeApplication.GetAll().ToList());
        }

       
    }
}