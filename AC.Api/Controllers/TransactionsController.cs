using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AC.Domain;
using AC.TransactionApp;
using AC.TransactionApp.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Controllers
{
    [Route("api/1.0/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Transactions>> Get([FromServices] TransactionsApplication transactionsApplication)
        {
            return Ok(transactionsApplication.GetTransactionsDependences());
        }

        [HttpPost("deposit")]
        public ActionResult<Transactions> PostDeposit(TransactionsDepositDTO transactionsDTO , [FromServices] TransactionsApplication transactionsApplication)
        {
            try
            {
                return Ok(transactionsApplication.PostDeposit(transactionsDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }

        [HttpPost("load")]
        public ActionResult<Transactions> PostLoad(TransactionsLoadDTO transactionsDTO, [FromServices] TransactionsApplication transactionsApplication)
        {
            try
            {
                return Ok(transactionsApplication.PostLoad(transactionsDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost("transference")]
        public ActionResult<Transactions> PostTransference(TransactionsTransferenceDTO transactionsDTO, [FromServices] TransactionsApplication transactionsApplication)
        {
            try
            {
                return Ok(transactionsApplication.PostTransference(transactionsDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("reversal")]
        public ActionResult<Transactions> PostReversal(TransactionsReversalDTO transactionsReversalDTO, [FromServices] TransactionsApplication transactionsApplication)
        {
            try
            {
                return Ok(transactionsApplication.PostReversal(transactionsReversalDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}