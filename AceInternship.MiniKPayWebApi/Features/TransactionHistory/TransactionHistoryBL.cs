namespace AceInternship.MiniKPayWebApi.Features.TransactionHistory
{
    public class TransactionHistoryBL
    {
        private readonly TransactionHistoryDA _transactionHistoryDA;
        public TransactionHistoryBL(TransactionHistoryDA transactionHistoryDA)
        {
            _transactionHistoryDA = transactionHistoryDA;
        }

        public void TransactionHistory(TransactionHistoryRequestModel requestModel)
        {
            _transactionHistoryDA.IsExistCustomerCode(requestModel.CustomerCode);
            _transactionHistoryDA.TransactionHistoryByCustomerCode(requestModel.CustomerCode);
        }
    }
}
