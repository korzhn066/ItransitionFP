using FinalProject.Domain.Models;
using MediatR;

namespace FinalProject.Application.Features.Item.Queries
{
    public class GetItemById : IRequest<Domain.Entities.Item>
    {
        public int Id { get; set; }
    }
}
