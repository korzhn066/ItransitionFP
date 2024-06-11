using FinalProject.Application.Features.Comment.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Comment.QueryHandlers
{
    internal class GetAllCommentsHandler : IRequestHandler<GetAllComments, List<Domain.Entities.Comment>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetAllCommentsHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<Domain.Entities.Comment>> Handle(GetAllComments request, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetAllAsync(request.ItemId);
        }
    }
}
