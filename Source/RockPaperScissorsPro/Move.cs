namespace RockPaperScissorsPro
{
  public abstract class Move
  {
    public bool CanBeat(Move move)
    {
      if (this is IllegalMove)
        return false;
      
      if (move is IllegalMove)
        return true;

      return CanBeatLegalMove(move);
    }

    protected abstract bool CanBeatLegalMove(Move move);
  }
}