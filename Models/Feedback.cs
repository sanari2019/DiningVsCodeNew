using System.ComponentModel.DataAnnotations;

namespace DiningVsCodeNew
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }  // Annotate with [Key] to indicate it's the primary key

        public int UserId { get; set; }

        public string Experience { get; set; }

        public bool ContactOption { get; set; }
    }
}
