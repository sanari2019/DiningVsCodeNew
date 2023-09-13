using DiningVsCodeNew.Models;

namespace DiningVsCodeNew
{

    public class PaymentByCust
    {
        public string enteredBy { get; set; }
        public string custCode { get; set; }
        public float totalAmount { get; set; }
        public string EnteredbyName { get; set; }
        public bool Freeze { get; set; }
    }

}