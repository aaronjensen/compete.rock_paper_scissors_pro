namespace RockPaperScissorsPro
{
  internal class PaperMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      if (move is RockMove)
        return true;

      return false;
    }

    public override string ToString()
    {
      return "Paper       ";
    }
  }
}