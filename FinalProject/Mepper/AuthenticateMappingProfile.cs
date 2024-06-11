using AutoMapper;
using FinalProject.Domain.Models;
using FinalProject.ViewModels.Account;

namespace FinalProject.Mepper
{
    public class AuthenticateMappingProfile : Profile
    {
        public AuthenticateMappingProfile()
        {
            CreateMap<RegisterViewModel, RegisterModel>();
            CreateMap<LoginViewModel, LoginModel>();
        }
    }
}
