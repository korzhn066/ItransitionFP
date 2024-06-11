using MediatR;

namespace FinalProject.Application.Features.Comment.Queries
{
    public class GetAllComments : IRequest<List<Domain.Entities.Comment>>
    {
        public int ItemId { get; set; }
    }
}
