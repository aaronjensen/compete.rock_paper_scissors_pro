using System;
using System.Linq;

namespace RockPaperScissorsPro
{
  public abstract class Move
  {
    public static Move Rock { get { return new RockMove(); } }
    public static Move Scissors { get { return new ScissorsMove(); } }
    public static Move Paper { get { return new PaperMove(); } }

    private Type[] ValidMoves = new [] { 
      typeof(RockMove), 
      typeof(ScissorsMove), 
      typeof(PaperMove), 
      typeof(DynamiteMove), 
      typeof(WaterBalloonMove) 
    };

    internal Move()
    {
    }

    public bool CanBeat(Move move)
    {
      if (!ValidMoves.Contains(GetType()))
        return false;

      if (!ValidMoves.Contains(move.GetType()))
        return true;

      return CanBeatLegalMove(move);
    }

    protected abstract bool CanBeatLegalMove(Move move);
  }

  public static class ProMove
  {
    public static Move Dynamite { get { return new DynamiteMove(); } }
  }

  public static class SuperProMove
  {
    public static Move WaterBalloon { get { return new WaterBalloonMove(); } }
  }
}