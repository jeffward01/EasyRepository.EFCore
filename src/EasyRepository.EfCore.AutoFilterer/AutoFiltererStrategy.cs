namespace EasyRepository.EfCore.AutoFilterer;

using EFCore.Abstractions.PagingFilters;
using global::AutoFilterer.Types;

public class AutoFiltererStrategy<TEntity> : FilterBase, IPagingFilterStrategy<TEntity, FilterBase, TEntity>
{
    /// <inheritdoc />
    public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> entity, FilterBase filter)
    {
        return filter.ApplyFilterTo(entity);
    }
}