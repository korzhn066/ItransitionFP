using FinalProject.Application.Features.Comment.Commands;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace FinalProject.Hubs
{
    public class CommentHub : Hub
    {
        private readonly IMediator _mediator;

        public CommentHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendComment(int itemId, string comment)
        {
            await _mediator.Send(new AddComment
            {
                ItemId = itemId,
                Comment = comment
            });

            await Clients.All.SendAsync(itemId.ToString(), comment);
        }
    }
}
