namespace DiningVsCodeNew.Models
{
    public class HistoryRecord
    {
        public DateTime DateServed { get; set; }
        public int PaymentMainId { get; set; }
        public int IsServed { get; set; }
        public string SourceTable { get; set; }
        public int Unit { get; set; }
        public int ServedBy { get; set; }
        public string FirstName { get; set; }
        public float Amount { get; set; }

    }

}