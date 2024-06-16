using System.Data;

namespace AceInternship.MiniKPayWebApi.Features.TransactionHistory
{
    public class TransactionHistoryDA
    {
        private readonly IDbConnection _db;

        public TransactionHistoryDA(IDbConnection db)
        {
            _db = db;
        }

        public bool IsExistCustomerCode(string customerCode)
        {
            return true;
        }

        public List<string> TransactionHistoryByCustomerCode(string customerCode)
        {
            return new List<string>();
        }
    }
}
