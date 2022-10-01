namespace EasyRepository.EFCore.Generic.PagingFilters;

using System;
using System.Linq;
using Abstractions.PagingFilters;

internal abstract class PagingFilterBase<TEntity, TFilter, TFilteredResponse> : IPagingFilterStrategy<TEntity, TFilter, TFilteredResponse>
{
    /// <inheritdoc />
    public IQueryable<TFilteredResponse> ApplyFilter(IQueryable<TEntity> entity, TFilter filter)
    {
        throw new NotImplementedException();
    }
}