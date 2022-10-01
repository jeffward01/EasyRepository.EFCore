namespace EasyRepository.EFCore.Abstractions.PagingFilters;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IPagingFilterStrategy<in TEntity, in TFilter, out TFilteredResponse>
{
      //IEnumerable<TFilteredResponse> GetMultipleByFilter(IQueryable<TEntity> entity, TFilter filter);
    
   // Task<ICollection<TFilteredResponse>> GetMultipleByFilterAsync(IEnumerable<TEntity> entity, TFilter filter);
    
     // TFilteredResponse GetSingleByFilter(IQueryable<TEntity> entity, TFilter filter);
    
     IQueryable<TFilteredResponse> ApplyFilter(IQueryable<TEntity> entity, TFilter filter);
    
}