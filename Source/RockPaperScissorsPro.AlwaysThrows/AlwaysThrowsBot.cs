using System;
using System.Collections.Generic;
using Compete.Bot;

namespace RockPaperScissorsPro.AlwaysThrows
{
  public class AlwaysThrowsPlayerFactory : IBotFactory
  {
    public IBot CreateBot()
    {
      return new AlwaysThrowsBot();
    }
  }

  public class AlwaysThrowsBot : IRockPaperScissorsBot
  {
    readonly Random _random = new Random();

    public Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules)
    {
      if (_random.NextDouble() > 0.5)
      {
        return Move.Paper;
      }
      return Move.Rock;
    }
  }
}
