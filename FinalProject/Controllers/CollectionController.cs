using FinalProject.Application.Features.Collection.Commands;
using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Application.Features.Item.Queries;
using FinalProject.ViewModels.Collection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace FinalProject.Controllers
{
    public class CollectionController : Controller
    {
        private readonly IMediator _mediator;

        public CollectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCollectionNameByItemId(int id)
        {
            var name =  await _mediator.Send(new GetCollectionNameByItemId
            {
                Id = id
            });

            return Ok(new
            {
                name = name
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetCollectionNameByCollectionId(int id)
        {
            var collection = await _mediator.Send(new GetCollectionById
            {
                Id = id
            });

            return Ok(new
            {
                name = collection.Name
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCollection(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCollection
            {
                Id = id
            },
            cancellationToken);

            return RedirectToAction("Index", "Home");   
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCollection(int id, CancellationToken cancellationToken)
        {
            var collection = await _mediator.Send(new GetCollectionById {
                Id = id
            },
            cancellationToken);

            return View(new UpdateCollectionViewModel
            {
                Id = id,
                Name = collection.Name,
                Description = collection.Description,
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCollection(UpdateCollectionViewModel model, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCollection
            {
                Id = model.Id,
                Name = model.Name ?? "",
                Description = model.Description ?? "",
            },
            cancellationToken);

            return RedirectToAction("Collection", new
            {
                id = model.Id,
            });
        }

        [HttpGet]
        public IActionResult AddCollection()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCollection(AddCollectionViewModel model, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddCollection
            {
                Username = HttpContext!.User!.Identity!.Name!,
                Name = model.Name ?? "",
                Description = model.Description ?? "",
                Tags = model.Tags,
            }, 
            cancellationToken);

            return RedirectToAction("UserCollections", "Account", new
            {
                username = HttpContext!.User!.Identity!.Name!
            });
        }

        public async Task<IActionResult> Collection(int id, int page, CancellationToken cancellationToken)
        {
            return View(new CollectionViewModel
            {
                Collection = await _mediator.Send(new GetCollectionById
                {
                    Id = id
                }, cancellationToken),
                Items = await _mediator.Send(new GetItemsByCollectionId
                {
                    CollectionId = id,
                    Count = 1000,
                    Page = page
                }, cancellationToken),
                Owner = await _mediator.Send(new GetCollectionOwnerById
                {
                    Id = id,
                }, cancellationToken)
            });
        }       
    }
}
