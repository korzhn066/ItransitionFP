using System.ComponentModel.DataAnnotations;

namespace FinalProject.Domain.Models
{
    public class TagBodyWithId
    {
        public int TagId { get; set; }

        public string? Body { get; set; }
    }
}
