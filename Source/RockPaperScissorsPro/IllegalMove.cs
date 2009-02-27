namespace RockPaperScissorsPro
{
  internal class IllegalMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      return false;
    }
  }
}