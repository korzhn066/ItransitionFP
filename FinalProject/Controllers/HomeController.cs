using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Application.Features.Item.Queries;
using FinalProject.Application.Features.Tag.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(new IndexViewModel
            {
                Collections = await _mediator.Send(new GetTheBiggestCollections
                {
                    Count = 5
                }, cancellationToken),
                
                Items = await _mediator.Send(new GetLastItems
                {
                    Count = 10
                }, cancellationToken),

                Tags = await _mediator.Send(new GetTheMostPopularTags
                {
                    Count = 20
                }, cancellationToken)
            });
        }
    }
}