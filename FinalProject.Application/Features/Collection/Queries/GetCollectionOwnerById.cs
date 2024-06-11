using MediatR;

namespace FinalProject.Application.Features.Collection.Queries
{
    public class GetCollectionOwnerById : IRequest<string>
    {
        public int Id { get; set; }
    }
}
