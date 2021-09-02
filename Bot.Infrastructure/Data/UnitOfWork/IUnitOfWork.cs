using System;
using System.Threading.Tasks;
using Infrastructure.Data.Repos.GenericRepository;
using Core.Models;

namespace Infrastructure.Data.UnitOfWork
{
  public interface IUnitOfWork : IDisposable
  {
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<int> Complete();
  }
}