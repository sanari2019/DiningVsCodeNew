namespace DiningVsCodeNew
{
    public class MealActivity
    {
        public int Id { get; set; }
        public int AvailableMealId { get; set; }
        public DateTime MadeActiveDate { get; set; }
        public string MadeActiveBy { get; set; }
        public DateTime? MadeInactiveDate { get; set; }
        public string MadeInactiveBy { get; set; }
    }
}