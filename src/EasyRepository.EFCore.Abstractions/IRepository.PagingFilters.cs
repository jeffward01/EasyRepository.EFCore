namespace EasyRepository.EFCore.Abstractions;

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

public partial interface IRepository
{
    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression" /> select expression,
    ///     <see cref="IIncludableQueryable{TEntity,TProperty}" /> include expression, <see cref="CancellationToken" />
    ///     cancellation token and <see cref="{TFilter}" /> filterable object <see cref="FilterBase" />. This method performs
    ///     get projected object with filter. In additional returns <see cref="{TProjected}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">The projected type to return</typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">The expression to create the projection object</param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : class;
}