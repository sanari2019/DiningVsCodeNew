
public class Transfer
{
    public int Id { get; set; }
    public int VoucherId { get; set; }
    public int Quantity { get; set; }
    public string TransferredBy { get; set; }
    public int EnteredBy { get; set; }
    public bool SNRead { get; set; }
    public string ByCustCode { get; set; }
    public int S_PymtMainId { get; set; }
    public string TransferredTo { get; set; }
    public int ReceivedBy { get; set; }
    public string ToCustCode { get; set; }
    public bool RNRead { get; set; }
    public int R_PymtMainId { get; set; }
    public DateTime DateTransferred { get; set; }
    public string TransferType { get; set; }
    public bool Success { get; set; }
}
