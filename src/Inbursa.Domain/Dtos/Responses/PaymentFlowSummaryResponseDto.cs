namespace Inbursa.Domain.Dtos.Responses
{
    public class PaymentFlowSummaryResponseDto
    {
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPayment { get; set; }
        public List<PaymentDetailResponseDto> PaymentSchedule { get; set; }
    }
}
