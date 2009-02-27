using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RockPaperScissorsPro.Bot
{
  public class MyBot : IRockPaperScissorsBot
  {
    private static readonly Random random = new Random(Guid.NewGuid().ToString().GetHashCode());
    private static readonly Move[] moves = new Move[] { Move.Paper, Move.Rock, Move.Scissors };

    public Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules)
    {
      return moves[random.Next(3)];
    }
  }
}