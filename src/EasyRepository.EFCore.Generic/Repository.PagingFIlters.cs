namespace EasyRepository.EFCore.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Abstractions.Enums;
using Abstractions.PagingFilters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;

internal partial class Repository
{
    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        
        var filterService = this._serviceProvider.GetRequiredService<IPagingFilterStrategy<TEntity, TFilter, TEntity>>();

        var queryable = this.FindQueryable<TEntity>(asNoTracking);

        queryable = filterService.ApplyFilter(queryable, filter);
        
        queryable = includeExpression(queryable);

        return await queryable.Select(projectExpression)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    public int Count<TEntity, TFilter>(TFilter filter)
        where TEntity : class
        where TFilter : class
    {
        var filterService = this._serviceProvider.GetRequiredService<IPagingFilterStrategy<TEntity, TFilter, TFilter>>();

        return filterService.ApplyFilter(
                this._context.Set<TEntity>()
                    .AsQueryable(),
                filter)
            .Count();
    }

    public async Task<int> CountAsync<TEntity, TFilter>(TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var filterService = this._serviceProvider.GetRequiredService<IPagingFilterStrategy<TEntity, TFilter, TFilter>>();

        var count = await filterService.ApplyFilter(
                this._context.Set<TEntity>()
                    .AsQueryable(),
                filter)
            .CountAsync(cancellationToken);

        return count;
    }


    public async Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var filterService = this._serviceProvider.GetRequiredService<IPagingFilterStrategy<TEntity, TFilter, TEntity>>();

        var queryable = this.FindQueryable<TEntity>(asNoTracking);

        queryable = filterService.ApplyFilter(queryable, filter);

        queryable = includeExpression(queryable);

        return await queryable.Select(projectExpression)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }


    /// <inheritdoc />
    public async Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var filterService = this._serviceProvider.GetRequiredService<IPagingFilterStrategy<TEntity, TFilter, TEntity>>();

        var queryable = this.FindQueryable<TEntity>(asNoTracking);

        queryable = filterService.ApplyFilter(queryable, filter);

        queryable = includeExpression(queryable);

        return await queryable.Select(projectExpression)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.Select(projectExpression)
            .ToList();
    }


    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public List<TEntity> GetMultiple<TEntity, TFilter>(bool asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : class
    {
        return this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .ToList();
    }

    /// <inheritdoc />
    public List<TEntity> GetMultiple<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : class
    {
        return this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .ToList();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(bool asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        return await this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        return await this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public List<TEntity> GetMultiple<TEntity, TFilter>(bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.ToList();
    }

    /// <inheritdoc />
    public List<TEntity> GetMultiple<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.ToList();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(
        bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return await queryable.ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return await queryable.ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : class
    {
        return this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .Select(projectExpression)
            .ToList();
    }

    /// <inheritdoc />
    public List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : class
    {
        return this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .Select(projectExpression)
            .ToList();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        return await this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .Select(projectExpression)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        return await this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter)
            .Select(projectExpression)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.Select(projectExpression)
            .ToList();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return await queryable.Select(projectExpression)
            .ToListAsync(cancellationToken)
            .ConfigureAwait(false);
    }


    /// <inheritdoc />
    public TProjected GetSingle<TEntity, TProjected, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.Select(projectExpression)
            .FirstOrDefault();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public TProjected GetSingle<TEntity, TProjected, TFilter>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.Select(projectExpression)
            .FirstOrDefault();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public TEntity GetSingle<TEntity, TFilter>(bool asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return queryable.FirstOrDefault();
    }

    /// <inheritdoc />
    public TEntity GetSingle<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return queryable.FirstOrDefault();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<TEntity> GetSingleAsync<TEntity, TFilter>(bool asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return await queryable.FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TEntity> GetSingleAsync<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return await queryable.FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public TEntity GetSingle<TEntity, TFilter>(bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.FirstOrDefault();
    }

    /// <inheritdoc />
    public TEntity GetSingle<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return queryable.FirstOrDefault();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<TEntity> GetSingleAsync<TEntity, TFilter>(
        bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return await queryable.FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TEntity> GetSingleAsync<TEntity, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);
        queryable = includeExpression(queryable);

        return await queryable.FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public TProjected GetSingle<TEntity, TProjected, TFilter>(bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return queryable.Select(projectExpression)
            .FirstOrDefault();
    }

    /// <inheritdoc />
    public TProjected GetSingle<TEntity, TProjected, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return queryable.Select(projectExpression)
            .FirstOrDefault();
    }

    [Obsolete("The boolean option for 'asNoTracking' is obsolete. Please use the Enum.EfTrackingOptions method instead of the boolean version.")]
    public async Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return await queryable.Select(projectExpression)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class
    {
        var queryable = this.FindQueryable<TEntity>(asNoTracking)
            .ApplyFilter(filter);

        return await queryable.Select(projectExpression)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);
    }
}