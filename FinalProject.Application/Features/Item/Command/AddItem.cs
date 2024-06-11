using FinalProject.Domain.Entities;
using FinalProject.Domain.Models;
using MediatR;

namespace FinalProject.Application.Features.Item.Command
{
    public class AddItem : IRequest
    {
        public int CollectionId { get; set; }
        public string Name { get; set; } = null!;
        public List<TagBodyWithId> TagsBodyWithId { get; set; } = null!;
    }
}
