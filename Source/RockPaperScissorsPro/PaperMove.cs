namespace RockPaperScissorsPro.Specs
{
  public class PaperMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      if (move is RockMove)
        return true;

      return false;
    }
  }
}