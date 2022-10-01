namespace EasyRepository.EfCore.AutoFilterer.Abstractions;

using System.Linq.Expressions;
using EFCore.Abstractions.Enums;
using global::AutoFilterer.Types;
using Microsoft.EntityFrameworkCore.Query;

public interface IRepository
{
     /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> pagination filter object. This method
    ///     performs generate LINQ expressions for Entities over DTOs automatically. In additional returns
    ///     <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    List<TEntity> GetMultiple<TEntity, TFilter>(bool asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> pagination filter object. This method
    ///     performs generate LINQ expressions for Entities over DTOs automatically. In additional returns
    ///     <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?  <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    List<TEntity> GetMultiple<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" />  pagination filter object and
    ///     <see cref="IIncludableQueryable{TEntity,TProperty}" /> include expression. This method performs get all entities
    ///     with apply filter and includable entities. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter Object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    List<TEntity> GetMultiple<TEntity, TFilter>(bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" />  pagination filter object and
    ///     <see cref="IIncludableQueryable{TEntity, TProperty}" /> include expression. This method performs get all entities
    ///     with apply filter and includable entities. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter Object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?   <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    List<TEntity> GetMultiple<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object and
    ///     <see cref="Expression{TDelegate}" /> project expression. This method performs get all projected objects with apply
    ///     filter. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter Object <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object <see cref="{TProjected}" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TProjected}" />
    /// </returns>
    List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object and
    ///     <see cref="Expression{Func}" /> project expression. This method performs get all projected objects with apply
    ///     filter. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter Object <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object <see cref="{TProjected}" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TProjected}" />
    /// </returns>
    List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object,
    ///     <see cref="Expression{Func}" /> project expression and <see cref="IIncludableQueryable{TEntity, TProperty}" />
    ///     include expression. This method performs get all projected objects with apply filter and get all includable
    ///     entities. In additional this method returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object,
    ///     <see cref="Expression{Func}" /> project expression and <see cref="IIncludableQueryable{TEntity, TProperty}" />
    ///     include expression. This method performs get all projected objects with apply filter and get all includable
    ///     entities. In additional this method returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?  <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    List<TProjected> GetMultiple<TEntity, TFilter, TProjected>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> pagination filter object and
    ///     <see cref="CancellationToken" />. This method performs generate LINQ expressions for Entities over DTOs
    ///     automatically async version. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(bool asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> pagination filter object and
    ///     <see cref="CancellationToken" />. This method performs generate LINQ expressions for Entities over DTOs
    ///     automatically async version. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object,
    ///     <see cref="IIncludableQueryable{TEntity, TProperty}" /> and <see cref="CancellationToken" /> cancellation token.
    ///     This method performs get all entities with apply filter and get all includable entities async version. In
    ///     additional this method returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(
        bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object,
    ///     <see cref="IIncludableQueryable{TEntity, TProperty}" /> and <see cref="CancellationToken" /> cancellation token.
    ///     This method performs get all entities with apply filter and get all includable entities async version. In
    ///     additional this method returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?  <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    Task<List<TEntity>> GetMultipleAsync<TEntity, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object and
    ///     <see cref="Expression{Func}" /> project expression. This method performs get all projected objects with apply
    ///     filter async version. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter Object <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object <see cref="{TProjected}" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TProjected}" />
    /// </returns>
    Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object and
    ///     <see cref="Expression{Func}" /> project expression. This method performs get all projected objects with apply
    ///     filter async version. In additional returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter Object <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object <see cref="{TProjected}" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TProjected}" />
    /// </returns>
    Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object,
    ///     <see cref="Expression{Func}" /> project expression and <see cref="IIncludableQueryable{TEntity, TProperty}" />
    ///     include expression. This method performs get all projected objects with apply filter and get all includable
    ///     entities async version. In additional this method returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="{TFilter}" /> paginationable filter object,
    ///     <see cref="Expression{Func}" /> project expression and <see cref="IIncludableQueryable{TEntity, TProperty}" />
    ///     include expression. This method performs get all projected objects with apply filter and get all includable
    ///     entities async version. In additional this method returns <see cref="List{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">
    ///     Type of projected object
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter dto <see cref="FilterBase" />
    /// </param>
    /// <param name="projectExpression">
    ///     Project expression <see cref="Expression{Func}" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="List{TEntity}" />
    /// </returns>
    Task<List<TProjected>> GetMultipleAsync<TEntity, TFilter, TProjected>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;
    
    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking and <see cref="{TFilter}" /> filter object. This object must be
    ///     type <see cref="FilterBase" />. This method perform get entity with filter. In additional returns
    ///     <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    TEntity GetSingle<TEntity, TFilter>(bool asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking and <see cref="{TFilter}" /> filter object. This object must be
    ///     type <see cref="FilterBase" />. This method perform get entity with filter. In additional returns
    ///     <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    TEntity GetSingle<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="IIncludableQueryable{TEntity, TProperty}" /> include
    ///     expression and <see cref="{TFilter}" /> filterable object <see cref="FilterBase" />. This method performs get and
    ///     includable entity with filter. In additional returns <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    TEntity GetSingle<TEntity, TFilter>(bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="IIncludableQueryable{TEntity, TProperty}" /> include
    ///     expression and <see cref="{TFilter}" /> filterable object <see cref="FilterBase" />. This method performs get and
    ///     includable entity with filter. In additional returns <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?   <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    TEntity GetSingle<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression and
    ///     <see cref="{TFilter}" /> filterable object <see cref="FilterBase" />. This method performs get projected object
    ///     with filter. In additional returns <see cref="{TProjected}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">The projection to return</typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    TProjected GetSingle<TEntity, TProjected, TFilter>(bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression and
    ///     <see cref="{TFilter}" /> filterable object <see cref="FilterBase" />. This method performs get projected object
    ///     with filter. In additional returns <see cref="{TProjected}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">The projection to return</typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?   <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    TProjected GetSingle<TEntity, TProjected, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression,
    ///     <see cref="IIncludableQueryable{TEntity, TProperty}" /> include expression and <see cref="{TFilter}" /> filterable
    ///     object <see cref="FilterBase" />. This method performs get projected object with filter. In additional returns
    ///     <see cref="{TProjected}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">The projection to return</typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    TProjected GetSingle<TEntity, TProjected, TFilter>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression,
    ///     <see cref="IIncludableQueryable{TEntity, TProperty}" /> include expression and <see cref="{TFilter}" /> filterable
    ///     object <see cref="FilterBase" />. This method performs get projected object with filter. In additional returns
    ///     <see cref="{TProjected}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">The projection to return</typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    TProjected GetSingle<TEntity, TProjected, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        where TEntity : class
        where TFilter : FilterBase;
    
    /// <summary>
    ///     This method takes <see cref="CancellationToken" /> cancellation token and <see cref="{TFilter}" /> filterable
    ///     object. This object must be inheritance <see cref="FilterBase" />. This method performs get count information of
    ///     entity with filter async version. In additional <see cref="int" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filterable object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="filter">
    ///     Filterable object <see cref="FilterBase" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="int" />
    /// </returns>
    Task<int> CountAsync<TEntity, TFilter>(TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;
    
    /// <summary>
    ///     This method takes <see cref="{TFilter}" /> filterable object. This object must be inheritance
    ///     <see cref="FilterBase" />. This method performs get count information of entity with filter. In additional
    ///     <see cref="int" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of filterable object <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="filter">
    ///     Filterable object <see cref="FilterBase" />
    /// </param>
    /// <returns>
    ///     Returns <see cref="int" />
    /// </returns>
    int Count<TEntity, TFilter>(TFilter filter)
        where TEntity : class
        where TFilter : FilterBase;
    
    
    
    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="CancellationToken" /> cancellation token and
    ///     <see cref="{TFilter}" /> filter object. This object must be type <see cref="FilterBase" />. This method perform get
    ///     entity with filter async version. In additional returns <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    Task<TEntity> GetSingleAsync<TEntity, TFilter>(bool asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="CancellationToken" /> cancellation token and
    ///     <see cref="{TFilter}" /> filter object. This object must be type <see cref="FilterBase" />. This method perform get
    ///     entity with filter async version. In additional returns <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    Task<TEntity> GetSingleAsync<TEntity, TFilter>(EfTrackingOptions asNoTracking, TFilter filter, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="IIncludableQueryable{TEntity, TProperty}" /> include
    ///     expression, <see cref="CancellationToken" /> cancellation token and <see cref="{TFilter}" /> filterable object
    ///     <see cref="FilterBase" />. This method performs get and includable entity with filter. In additional returns
    ///     <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? Default value : false <see cref="bool" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    Task<TEntity> GetSingleAsync<TEntity, TFilter>(
        bool asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;


    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="IIncludableQueryable{TEntity, TProperty}" /> include
    ///     expression, <see cref="CancellationToken" /> cancellation token and <see cref="{TFilter}" /> filterable object
    ///     <see cref="FilterBase" />. This method performs get and includable entity with filter. In additional returns
    ///     <see cref="{TEntity}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core?  <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="includeExpression">
    ///     Include expression <see cref="IIncludableQueryable{TEntity, TProperty}" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TEntity}" />
    /// </returns>
    Task<TEntity> GetSingleAsync<TEntity, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression,
    ///     <see cref="CancellationToken" /> cancellation token and <see cref="{TFilter}" /> filterable object
    ///     <see cref="FilterBase" />. This method performs get projected object with filter. In additional returns
    ///     <see cref="{TProjected}" />
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
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        bool asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;

    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression,
    ///     <see cref="CancellationToken" /> cancellation token and <see cref="{TFilter}" /> filterable object
    ///     <see cref="FilterBase" />. This method performs get projected object with filter. In additional returns
    ///     <see cref="{TProjected}" />
    /// </summary>
    /// <typeparam name="TEntity">
    ///     Type of Entity
    /// </typeparam>
    /// <typeparam name="TFilter">
    ///     Type of Filter <see cref="FilterBase" />
    /// </typeparam>
    /// <typeparam name="TProjected">The projected type to return</typeparam>
    /// <param name="asNoTracking">
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
    /// </param>
    /// <param name="filter">
    ///     Filter object of type FilterBase <see cref="FilterBase" />
    /// </param>
    /// <param name="cancellationToken"> A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>
    ///     Returns <see cref="{TProjected}" />
    /// </returns>
    Task<TProjected> GetSingleAsync<TEntity, TProjected, TFilter>(
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;




    /// <summary>
    ///     This method takes <see cref="bool" /> asNoTracking, <see cref="Expression{Func}" /> select expression,
    ///     <see cref="IIncludableQueryable{TEntity, TProperty}" /> include expression, <see cref="CancellationToken" />
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
    ///     Do you want the entity to be tracked by EF Core? <see cref="EfTrackingOptions" />
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
        EfTrackingOptions asNoTracking, TFilter filter, Expression<Func<TEntity, TProjected>> projectExpression,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression, CancellationToken cancellationToken = default)
        where TEntity : class
        where TFilter : FilterBase;


}