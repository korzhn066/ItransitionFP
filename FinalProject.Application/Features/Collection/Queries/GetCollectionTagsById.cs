using MediatR;

namespace FinalProject.Application.Features.Collection.Queries
{
    public  class GetCollectionTagsById : IRequest<List<Domain.Entities.Tag>>
    {
        public int Id { get; set; }
    }
}
