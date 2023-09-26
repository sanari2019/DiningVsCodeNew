using DiningVsCodeNew.Models; // Add this using directive

namespace DiningVsCodeNew.Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
    }
}
