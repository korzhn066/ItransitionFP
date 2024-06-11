using FinalProject.Application.Models;
using MediatR;

namespace FinalProject.Application.Features.ApplicationUser.Queries
{
    public class GetApplicationUsers : IRequest<List<ApplicationUserWithAdminRole>>
    {
    }
}
