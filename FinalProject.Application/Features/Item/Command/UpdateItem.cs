using MediatR;

namespace FinalProject.Application.Features.Item.Command
{
    public class UpdateItem : IRequest
    {
        public Domain.Entities.Item Item { get; set; } = null!;
    }
}
