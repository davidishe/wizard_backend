using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data.Spec;
using Core.Models;

namespace Infrastructure.Data.Repos.GenericRepository
{
  public interface IGenericRepository<T> where T : BaseEntity
  {
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<int> CountAsync(ISpecification<T> spec);
    Task<T> AddEntityAsync(T entity);

    T Update(T entity);
    void Delete(T entity);


    // Task<IReadOnlyList<AnimalRegion>> CreateProductRegionAsync(AnimalRegion productRegion);
    // Task<IReadOnlyList<AnimalType>> CreateProductTypeAsync(AnimalType productType);
  }
}