namespace DiningVsCodeNew
{
    public class AvailableMeal
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string MealType { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public bool Active { get; set; }
    }
}