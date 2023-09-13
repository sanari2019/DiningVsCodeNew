namespace DiningVsCodeNew
{
    public class Voucher
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public float Amount { get; set; }

        public int Custtypeid { get; set; }

        public string custname { get; set; }
        public bool isVisible { get; set; }
    }

}