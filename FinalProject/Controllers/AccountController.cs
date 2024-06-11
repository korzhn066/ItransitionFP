using AutoMapper;
using FinalProject.Application.Features.ApplicationUser.Queries;
using FinalProject.Application.Features.Collection.Queries;
using FinalProject.Domain.Interfaces.Repositories;
using FinalProject.Domain.Interfaces.Services;
using FinalProject.Domain.Models;
using FinalProject.ViewModels.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationAuthenticateService _applicationAuthenticateService;
        private readonly IJiraRepository _jiraRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(
            IApplicationAuthenticateService applicationAuthenticateService,
            IJiraRepository jiraRepository,
            IMediator mediator,
            IMapper mapper)
        {
            _applicationAuthenticateService = applicationAuthenticateService;
            _jiraRepository = jiraRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserEmail()
        {
            var email = await _mediator.Send(new GetUserEmail
            {
                UserName = HttpContext.User.Identity!.Name!
            });

            return Ok(new
            {
                Email = email,
            });
        }

        public async Task<IActionResult> UserCollections(string username, int page)
        {
            var accountId = await _mediator.Send(new GetJiraAccountId
            {
                UserName = username
            });

            return View(new UserCollectionsViewModel
            {
                Collections = await _mediator.Send(new GetCollectionsByUsername
                {
                    Username = username,
                    Page = page,
                    Count = 10
                }),
                MaxCount = 10,
                Owner = username,
                CurrentPage = page,
                Issues = await _jiraRepository.GetIssuesAsync(accountId ?? ""),
            });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _applicationAuthenticateService.LogOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationAuthenticateService.RegisterAsync(
                    _mapper.Map<RegisterModel>(model)
                    );

                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _applicationAuthenticateService.LoginAsync(
                    _mapper.Map<LoginModel>(model)
                    );

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }

            return View(model);
        }
    }
}
