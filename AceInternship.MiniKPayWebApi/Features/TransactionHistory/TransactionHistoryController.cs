using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AceInternship.MiniKPayWebApi.Features.TransactionHistory
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionHistoryController : ControllerBase
    {
        private readonly TransactionHistoryBL _transactionHistoryBL;

        public TransactionHistoryController(TransactionHistoryBL transactionHistoryBL)
        {
            _transactionHistoryBL = transactionHistoryBL;
        }

        [HttpPost]
        public IActionResult TranscationHistory(TransactionHistoryRequestModel requestModel)
        {
            try
            {
                if (string.IsNullOrEmpty(requestModel.CustomerCode))
                {
                    return BadRequest("Invalid Customer Code.");
                }
                _transactionHistoryBL.TransactionHistory(requestModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
