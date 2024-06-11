using FinalProject.Domain.Entities;
using FinalProject.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.ViewModels.Item
{
    public class AddItemViewModel
    {
        public int CollectionId { get; set; }
        public List<Tag> Tags { get; set; } = null!;
        public string Name { get; set; } = null!;
        public List<TagBodyWithId> TagsBodyWithId { get; set; } = null!;
        public bool IsError { get; set; } = false;
    }
}
