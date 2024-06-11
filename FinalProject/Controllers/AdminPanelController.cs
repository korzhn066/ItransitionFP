using FinalProject.Application.Features.ApplicationUser.Commands;
using FinalProject.Application.Features.ApplicationUser.Queries;
using FinalProject.ViewModels.AdminPanel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IMediator _mediator;

        public AdminPanelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Block(List<string> usersId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new BlockUsers
            {
                UsersId = usersId
            }, 
            cancellationToken);

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        [HttpPost]
        public async Task<IActionResult> Unblock(List<string> usersId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UnblockUsers
            {
                UsersId = usersId
            },
            cancellationToken);

            return RedirectToAction("AdminPanel", "AdminPanel");
        }

        [HttpGet]
        public async Task<IActionResult> AdminPanel(CancellationToken cancellationToken)
        {
            return View(new AdminPanelViewModel 
            { 
                ApplicationUserWithAdminRoles = await _mediator.Send(new GetApplicationUsers(), cancellationToken)
            });
        }
    }
}
