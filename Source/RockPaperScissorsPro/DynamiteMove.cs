namespace RockPaperScissorsPro
{
  internal class DynamiteMove : Move
  {
    protected override bool CanBeatLegalMove(Move move)
    {
      if (move is RockMove
          || move is PaperMove
          || move is ScissorsMove)
        return true;

      return false;
    }

    public override string ToString()
    {
      return "Dynamite    ";
    }
  }
}