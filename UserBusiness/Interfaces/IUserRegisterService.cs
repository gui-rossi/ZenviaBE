using UserDomain.ViewModels;

namespace UserBusiness.Interfaces
{
    public interface IUserRegisterService
    {
        Task AddNewUser(UserViewModel userVM);
        Task<ICollection<UserViewModel>> FetchAllUsers();
        Task ModifyUser(UserViewModel userVM);
    }
}
