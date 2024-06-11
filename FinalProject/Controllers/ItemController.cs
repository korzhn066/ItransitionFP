using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Application.Features.Comment.Queries;
using FinalProject.Application.Features.Item.Command;
using FinalProject.Application.Features.Item.Queries;
using FinalProject.Domain.Entities;
using FinalProject.ViewModels;
using FinalProject.ViewModels.Item;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ItemList(int tagId, CancellationToken cancellationToken)
        {
            return View(new ItemListViewModel
            {
                Items = await _mediator.Send(new GetItemsByTagId
                {
                    TagId = tagId
                }, cancellationToken),
            });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItem(UpdateItemViewModel model, CancellationToken cancellationToken)
        {
            var isValid = true;

            foreach (var tagItems in model.Item.TagItems)
            {
                if (tagItems is null)
                {
                    isValid = false;
                }
            }

            if (model.Item.Name is not null && isValid)
            {
                await _mediator.Send(new UpdateItem
                {
                    Item = model.Item,
                }, cancellationToken);

                return RedirectToAction("Item", new
                {
                    id = model.Item.Id
                });
            }

            return View(new UpdateItemViewModel
            {
                Item = await _mediator.Send(new GetItemById
                {
                    Id = model.Item.Id,
                }, cancellationToken),
                IsValid = false
            });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateItem(int id, CancellationToken cancellationToken)
        {
            return View(new UpdateItemViewModel
            {
                Item = await _mediator.Send(new GetItemById
                {
                    Id = id
                }, cancellationToken),
                IsValid = true
            });
        }

        public async Task<IActionResult> DeleteItem(int id, int collectionId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteItem
            {
                Id = id
            }, cancellationToken);

            return RedirectToAction("Collection", "Collection", new {
                id = collectionId
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemViewModel model, CancellationToken cancellationToken)
        {
            bool valid = true;

            foreach (var tag in model.TagsBodyWithId)
            {
                if (tag.Body is null)
                {
                    valid = false;
                    break;
                }
            }

            if (model.Name is not null && valid)
            {
                await _mediator.Send(new AddItem
                {
                    CollectionId = model.CollectionId,
                    Name = model.Name,
                    TagsBodyWithId = model.TagsBodyWithId,
                }, cancellationToken);

                return RedirectToAction("Collection", "Collection", new
                {
                    id = model.CollectionId
                });
            }
            else
            {
                model.IsError = true;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddItem(int collectionId, CancellationToken cancellationToken)
        {
            return View(new AddItemViewModel
            {
                CollectionId = collectionId,
                Tags = await _mediator.Send(new GetCollectionTagsById
                {
                    Id = collectionId
                }, cancellationToken)
            });
        }

        public async Task<IActionResult> Item(int id, CancellationToken cancellationToken)
        {
            var owner = await _mediator.Send(new GetItemOwnerById
            {
                Id = id
            });

            var username = HttpContext.User.Identity.Name;

            if (username is null)
            {
                ViewBag.IsOwner = false;
            }
            else
            {
                ViewBag.IsOwner = owner == username;
            }

            var item = await _mediator.Send(new GetItemById
            {
                Id = id
            }, cancellationToken);

            return View(new ItemViewModel
            {
                Item = item,
                Owner = owner,
                Comments = await _mediator.Send(new GetAllComments
                {
                    ItemId = id
                })
            });
        }
    }
}
