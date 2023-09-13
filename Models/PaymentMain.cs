using DiningVsCodeNew.Models;

namespace DiningVsCodeNew
{
    public class PaymentMain
    {
        public int Id { get; set; }
        public DateTime DateEntered { get; set; }
        public string EnteredBy { get; set; }
        public int CustTypeiD { get; set; }
        public string? CustCode { get; set; }
        public int VoucherId { get; set; }
        public int Unit { get; set; }
        public float Amount { get; set; }
        public Boolean Served { get; set; }
        public DateTime DateServed { get; set; }
        public string ServedBy { get; set; }
        public int Paymentmodeid { get; set; }
        public Boolean Paid { get; set; }

        public DateTime timepaid { get; set; }
        public int opaymentid { get; set; }

        public OnlinePayment onlinePayment { get; set; }
        public int PaymentType { get; set; }

        public string VoucherDescription { get; set; }

    }

}