using FinalProject.Application.Features.ApplicationUser.Commands;
using FinalProject.Application.Features.ApplicationUser.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FinalProject.Controllers
{
    [Authorize]
    public class JiraController : Controller
    {
        private readonly IJiraRepository _jiraRepository;
        private readonly IMediator _mediator;
        public JiraController(
            IJiraRepository jiraRepository,
            IMediator mediator)
        {
            _jiraRepository = jiraRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendIssue(string summary, string collection, string url, string priority, string email)
        {
            var userId = await _jiraRepository.CreateUserAsync(email);

            if (userId is null)
            {
                return BadRequest();
            }

            await _jiraRepository.AddUserToRoleAsync(userId);

            var username = HttpContext.User.Identity!.Name!;

            await _mediator.Send(new ChangeUserJiraAccountId
            {
                JiraAccountId = userId,
                UserName = username,
            });

            await _mediator.Send(new ChangeUserEmail
            {
                Email = email,
                UserName = username,
            });

            await _jiraRepository.CreateIssueAsync(summary, collection, url, priority, email, userId);

            return NoContent();
        }
    }
}
