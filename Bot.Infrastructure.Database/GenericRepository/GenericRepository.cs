using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Bot.Infrastructure.Database;
using Bot.Infrastructure.Specifications;

namespace Infrastructure.Database
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {

    private readonly AppDbContext _context;
    public GenericRepository(
      AppDbContext context
    )
    {
      _context = context;
    }


    #region generic methods
    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }


    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
      var result = ApplySpecification(spec);
      var resultToReturn = await result.ToListAsync();
      return resultToReturn;
    }


    public async Task<T> GetByIdAsync(int id)
    {
      return await _context.Set<T>().FindAsync(id);
    }


    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).FirstOrDefaultAsync();
    }


    public async Task<T> AddEntityAsync(T entity)
    {
      var updatedEntity = await _context.Set<T>().AddAsync(entity);
      SaveChanges();
      return updatedEntity.Entity;
    }

    public T Update(T entity)
    {
      _context.Set<T>().Attach(entity);
      _context.Entry(entity).State = EntityState.Modified;
      SaveChanges();
      return entity;
    }


    void IGenericRepository<T>.Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
      SaveChanges();
    }


    private void SaveChanges()
    {
      _context.SaveChanges();
    }


    public async Task<int> CountAsync(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).CountAsync();
    }


    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
      var result = SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
      return result;
    }

    #endregion


  }
}