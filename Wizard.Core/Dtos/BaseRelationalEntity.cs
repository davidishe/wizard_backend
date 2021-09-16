using Core.Models;

namespace Wizard.Core.Dtos
{
  public class BaseRelationalEntity : BaseEntity
  {
    public int TEntityId { get; set; }
    public BaseEntity? TEntity { get; set; }
    public int TObjectId { get; set; }
    public BaseEntity? TObject { get; set; }

  }
}