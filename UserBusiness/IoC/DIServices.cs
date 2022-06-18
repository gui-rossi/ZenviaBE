using Microsoft.Extensions.DependencyInjection;
using UserBusiness.Interfaces;
using UserBusiness.Services;

namespace UserBusiness.IoC
{
    public static class DIServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IUserRegisterService, UserRegisterService>();
        }
    }
}
