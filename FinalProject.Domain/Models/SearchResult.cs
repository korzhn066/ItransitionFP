using FinalProject.Domain.Enums;

namespace FinalProject.Domain.Models
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public SearchResultType ResultType { get; set; }
    }
}
