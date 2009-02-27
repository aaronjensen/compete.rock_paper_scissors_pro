using System;
using System.Collections.Generic;
using Compete.Model.Game;

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
        return new PaperMove();
      }
      return new RockMove();
    }
  }
}
