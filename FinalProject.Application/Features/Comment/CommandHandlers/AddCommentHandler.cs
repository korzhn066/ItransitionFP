using FinalProject.Application.Features.Comment.Commands;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;

namespace FinalProject.Application.Features.Comment.CommandHandlers
{
    internal class AddCommentHandler : IRequestHandler<AddComment>
    {
        private readonly ICommentRepository _commentRepository;

        public AddCommentHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(AddComment request, CancellationToken cancellationToken)
        {
            var comment = new Domain.Entities.Comment { 
                ItemId = request.ItemId,
                Message = request.Comment
            };

            await _commentRepository.AddAsync(comment);

            await _commentRepository.SaveChangesAsync();
        }
    }
}
