namespace RockPaperScissorsPro
{
  public class TimeoutMove : IllegalMove
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      return false;
    }
  }
}