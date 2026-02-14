using Activity.Data;
using Activity.Model.POS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Activity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public TransactionsController(ApplicationDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransaction()
        {
            var transactions = await _dbContext.Transactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTransactionById(Guid id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            transaction.TransactionId = Guid.NewGuid();
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.TransactionId }, transaction);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateTransaction([FromRoute] Guid id, [FromBody] Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest();
            }

            var existingTransaction = await _dbContext.Transactions.FindAsync(id);

            if (existingTransaction == null)
            {
                return NotFound();
            }

            existingTransaction.TransactionDate = transaction.TransactionDate;
            existingTransaction.ProductName = transaction.ProductName;
            existingTransaction.ProductId = transaction.ProductId;
            existingTransaction.Quantity = transaction.Quantity;
            existingTransaction.Total = transaction.Total;
            existingTransaction.Change = transaction.Change;

            await _dbContext.SaveChangesAsync();

            return Ok(existingTransaction);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] Guid id)
        {
            var transaction = await _dbContext.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            _dbContext.Transactions.Remove(transaction);
            await _dbContext.SaveChangesAsync();

            return Ok(transaction);
        }
    }
}
