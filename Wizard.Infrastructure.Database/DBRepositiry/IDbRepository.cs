using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Wizard.Infrastructure.Database
{
  public interface IDbRepository<TEntity> where TEntity : BaseEntity
  {
    IQueryable<TEntity> GetAll();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(int id);

  }
}
