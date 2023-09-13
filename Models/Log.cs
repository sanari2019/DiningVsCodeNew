 public class Log
    {
        public int time_spent { get; set; }
        public int attempts { get; set; }
        public string authentication { get; set; }
        public int errors { get; set; }
        public bool success { get; set; }
        public bool mobile { get; set; }
        public List<object> input { get; set; }
        public object channel { get; set; }
        public List<History> history { get; set; }
    }