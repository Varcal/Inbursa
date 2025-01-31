namespace Inbursa.Domain.Entities
{
    public class PaymentFlowSummary
    {
        public int Id { get; private set; }
        public int PropostaId { get; private set; }
        public decimal MonthlyPayment { get; private set; }
        public decimal TotalInterest { get; private set; }
        public decimal TotalPayment { get; private set; }
        public ICollection<PaymentDetail> PaymentSchedule { get; private set; }


        private PaymentFlowSummary() { } 

        public PaymentFlowSummary(decimal monthlyPayment, decimal totalInterest, decimal totalPayment, List<PaymentDetail> paymentSchedule)
        {
            MonthlyPayment = monthlyPayment;
            TotalInterest = totalInterest;
            TotalPayment = totalPayment;
            PaymentSchedule = paymentSchedule;
        }
    }
}
