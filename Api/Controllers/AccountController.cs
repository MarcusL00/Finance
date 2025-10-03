using Api.Data;
using Api.Models;
using Api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AccountController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var allAccounts = dbContext.Accounts.ToList();
            return Ok(allAccounts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetAccountById(Guid id)
        {
            var account = dbContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateAccount(Guid id, AccountDto accountDto)
        {
            var account = dbContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            account.Name = accountDto.Name;
            account.Email = accountDto.Email;
            account.PhoneNumber = accountDto.PhoneNumber;
            account.CreatedAt = account.CreatedAt;
            dbContext.SaveChanges();


            return Ok(account);
        }


        [HttpDelete]
        public IActionResult DeleteAccountById(Guid id)
        {
            var account = dbContext.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            dbContext.Accounts.Remove(account);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IActionResult SaveAccount(AccountDto accountDto)
        {
            var accountEnitity = new Account()
            {
                Id = Guid.NewGuid(),
                Name = accountDto.Name,
                Email = accountDto.Email,
                PhoneNumber = accountDto.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.Add(accountEnitity);
            dbContext.SaveChanges();

            return Ok(accountEnitity);
        }
    }
}
