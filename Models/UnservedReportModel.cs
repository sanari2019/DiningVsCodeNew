public class UnservedReportModel
{
    public int PaymentMainId { get; set; }
    public int TotalUnits { get; set; }
    public string EnteredByUsername { get; set; }
    public DateTime DateEntered { get; set; }
    public string VoucherDescription { get; set; }
    public int ServedUnits { get; set; }
    public int RemainingUnits { get; set; }
}
