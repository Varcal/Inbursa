namespace Inbursa.Domain.Entities
{
    public class PaymentDetail
    {
        public int Id { get; private set; }
        public int Month { get; private set; }
        public decimal Principal { get; private set; }
        public decimal Interest { get; private set; }
        public decimal Balance { get; private set; }
        public int PaymentFlowSummaryId { get; private set; }

        private PaymentDetail() { }

        public PaymentDetail(int month, decimal principal, decimal interest, decimal balance)
        {
            Month = month;
            Principal = principal;
            Interest = interest;
            Balance = balance;
        }
    }
}
