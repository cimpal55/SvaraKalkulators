using SvaraKalkulators.Core.Data.Repositories.Interfaces;
using SvaraKalkulators.Core.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SvaraKalkulators.Core.Data.Utils.ServiceRegistration
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddStockAccountingRepositories(this IServiceCollection @this) =>
            @this
                .AddRepositories();

        private static IServiceCollection AddRepositories(this IServiceCollection @this) =>
            @this
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
