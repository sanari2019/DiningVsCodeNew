// Model class
public class ServedAlacarteVoucherModel
{
    public int Id { get; set; }
    public DateTime DateEntered { get; set; }
    public string CustTypeName { get; set; }
    public string MenuName { get; set; }
    public decimal MaxTarriff { get; set; }
    public DateTime? DateServed { get; set; }
}
