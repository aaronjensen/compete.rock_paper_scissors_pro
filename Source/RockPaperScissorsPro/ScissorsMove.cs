namespace RockPaperScissorsPro
{
  public class ScissorsMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      if (move is PaperMove)
        return true;

      return false;
    }
  }
}