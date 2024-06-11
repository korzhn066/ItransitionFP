using MediatR;

namespace FinalProject.Application.Features.Item.Command
{
    public class DeleteItem : IRequest
    {
        public int Id { get; set; }
    }
}
