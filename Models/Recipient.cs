 public class Recipient
    {
        public bool active { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public string domain { get; set; }
        public object email { get; set; }
        public int id { get; set; }
        public int integration { get; set; }
        public object metadata { get; set; }
        public string name { get; set; }
        public string recipient_code { get; set; }
        public string type { get; set; }
        public bool is_deleted { get; set; }
        public Details details { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }