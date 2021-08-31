namespace Core.Models
{

  public class HeadManager : BaseEntity
  {

    public int? MemberId { get; set; }
    public Member? Member { get; set; }

    public int? HeadManagerPositionId { get; set; }
    public HeadManagerPosition? HeadManagerPosition { get; set; }

  }
}