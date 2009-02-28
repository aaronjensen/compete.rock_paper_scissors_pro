namespace RockPaperScissorsPro
{
  internal class TimeoutMove : IllegalMove
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      return false;
    }

    public override string ToString()
    {
      return "Timeout     ";
    }
  }
}