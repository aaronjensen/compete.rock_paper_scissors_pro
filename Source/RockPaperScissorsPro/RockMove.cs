namespace RockPaperScissorsPro
{
  public class RockMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      if (move is ScissorsMove)
        return true;

      return false;
    }
  }
}