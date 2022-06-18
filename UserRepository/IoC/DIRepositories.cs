using Microsoft.Extensions.DependencyInjection;
using UserRepository.DataRepository;
using UserRepository.Interface;

namespace UserRepository.IoC
{
    public static class DIRepositories
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
        }
    }
}
