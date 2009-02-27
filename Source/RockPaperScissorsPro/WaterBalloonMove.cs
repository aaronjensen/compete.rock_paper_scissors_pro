namespace RockPaperScissorsPro
{
  public class WaterBalloonMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      if (move is DynamiteMove)
        return true;

      return false;
    }
  }
}