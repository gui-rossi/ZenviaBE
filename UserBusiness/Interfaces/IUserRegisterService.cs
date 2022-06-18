using UserDomain.ViewModels;

namespace UserBusiness.Interfaces
{
    public interface IUserRegisterService
    {
        Task AddNewUser(UserViewModel userVM);
    }
}
