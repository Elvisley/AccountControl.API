using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AC.AccountsApp;
using AC.AccountsApp.DataTransferObject;
using AC.Domain;

using Microsoft.AspNetCore.Mvc;

namespace AC.Api.Controllers
{
    [ApiController]
    [Route("api/1.0/accounts")]
    public class AccountsController : ControllerBase
    {
        /// <summary>
        /// Busca todas as contas cadastradas como principal
        /// </summary>
        /// <param name="accountApplication"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll( [FromServices] AccountApplication accountApplication)
        {
            try
            {
                return Ok(accountApplication.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("master")]
        public IActionResult GetAllAccountsMaster([FromServices] AccountApplication accountApplication)
        {
            try
            {
                return Ok(accountApplication.GetAllAccountsMaster());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id, [FromServices] AccountApplication accountApplication)
        {
            try
            {
                return Ok(accountApplication.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost("full")]
        public IActionResult PostFull(AccountFullDTO account, [FromServices] AccountApplication accountApplication)
        {

            try
            {
                return Ok(accountApplication.PostFull(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("master")]
        public IActionResult Post(AccountMasterDTO account, [FromServices] AccountApplication accountApplication)
        {

            try
            {
                return Ok(accountApplication.Created(account));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AccountUpdated account, [FromServices] AccountApplication accountApplication)
        {

            try
            {
                return Ok(accountApplication.Updated(id, account));
            }

            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("children")]
        public IActionResult PostChildren(AccountChildrenDTO account, [FromServices] AccountApplication accountApplication)
        {

            try
            {
                return Ok(accountApplication.CreatedChildren(account));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("children")]
        public IActionResult GetChildrenAccounts(int childrenAccountsId, [FromServices] AccountApplication accountApplication)
        {
            try
            {
                return Ok(accountApplication.GetChildrenAccounts(childrenAccountsId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
    }
}