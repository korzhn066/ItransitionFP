using MediatR;

namespace FinalProject.Application.Features.Collection.Queries
{
    public class GetCollectionById : IRequest<Domain.Entities.Collection>
    {
        public int Id { get; set; }
    }
}
