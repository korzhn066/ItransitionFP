using MediatR;

namespace FinalProject.Application.Features.Item.Queries
{
    public class GetItemOwnerById : IRequest<string>
    {
        public int Id { get; set; }
    }
}
