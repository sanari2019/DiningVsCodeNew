namespace DiningVsCodeNew
{
    public class Mealtariff
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public Menu menu { get; set; }
        public float Tariff { get; set; }
        public DateTime Datechanged { get; set; }

        public bool active { get; set; }
    }

}