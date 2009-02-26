namespace RockPaperScissorsPro.Specs
{
  public class Player
  {
    public int DynamiteRemaining
    {
      get; set;
    }

    public bool HasDynamite
    {
      get { return DynamiteRemaining > 0; }
    }
  }
}