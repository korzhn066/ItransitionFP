using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Application.Features.Item.Queries;
using FinalProject.Application.Features.Tag.Queries;
using FinalProject.Domain.Enums;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly IMediator _mediator;

        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> SearchTags(string text, CancellationToken cancellationToken)
        {
            var tags = await _mediator.Send(new GetTagsByPattern
            {
                Count = 5,
                Text = text
            }, cancellationToken);

            return Ok(new
            {
                Tags = tags
            });
        }

        public async Task<IActionResult> Search(string text, CancellationToken cancellationToken)
        {
            var maxCount = 5;

            var result = await SearchInItems(text, maxCount, cancellationToken);

            if (result.Count != maxCount)
                result.AddRange(await SearchInCollections(text, maxCount - result.Count, cancellationToken));

            return Ok(new { result });
        }

        private async Task<List<SearchResult>> SearchInItems(string text, int count, CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetItemsByContainText
            {
                Text = text,
                Count = count
            }, cancellationToken);

            var result = new List<SearchResult>();

            foreach (var item in items)
            {
                result.Add(new SearchResult
                {
                    Id = item.Id,
                    Name = item.Name,
                    ResultType = SearchResultType.Item
                });
            }

            return result;
        }

        private async Task<List<SearchResult>> SearchInCollections(string text, int count, CancellationToken cancellationToken)
        {
            var items = await _mediator.Send(new GetCollectionsByContainText
            {
                Text = text,
                Count = count
            }, cancellationToken);

            var result = new List<SearchResult>();

            foreach (var item in items)
            {
                result.Add(new SearchResult
                {
                    Id = item.Id,
                    Name = item.Name,
                    ResultType = SearchResultType.Collection
                });
            }

            return result;
        }
    }
}
