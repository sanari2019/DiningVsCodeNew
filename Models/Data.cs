public class Data
{
    public int id { get; set; }
    public string domain { get; set; }
    public string status { get; set; }
    public string reference { get; set; }
    public int amount { get; set; }
    public object message { get; set; }
    public string gateway_response { get; set; }
    public DateTime paid_at { get; set; }
    public DateTime created_at { get; set; }
    public string channel { get; set; }
    public string currency { get; set; }
    public string ip_address { get; set; }
    public Metadata metadata { get; set; }
    public Log log { get; set; }
    public object fees { get; set; }
    public Customer customer { get; set; }
    public Authorization authorization { get; set; }
    public Plan plan { get; set; }
    public object failures { get; set; }
    public Integration integration { get; set; }
    public string reason { get; set; }
    public string source { get; set; }
    public object source_details { get; set; }
    public object titan_code { get; set; }
    public string transfer_code { get; set; }
    public object transferred_at { get; set; }
    public Recipient recipient { get; set; }
    public Session session { get; set; }
    public DateTime updated_at { get; set; }
}
