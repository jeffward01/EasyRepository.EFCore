namespace EasyRepository.EfCore.AutoFilterer.Container;

using EFCore.Abstractions.PagingFilters;
using Microsoft.Extensions.DependencyInjection;

public static class EasyRepositoryAutoFilterContainer
{
    public static void EasyRepositoryAutoFilterer(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPagingFilterStrategy<,,>), typeof(AutoFiltererStrategy<>));
    }
}