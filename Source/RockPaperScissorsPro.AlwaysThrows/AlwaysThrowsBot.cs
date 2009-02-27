using System;
using System.Collections.Generic;
using Compete.Model.Game;

namespace RockPaperScissorsPro.AlwaysThrows
{
  public class AlwaysThrowsPlayerFactory : IBotFactory
  {
    public IBot CreateBot()
    {
      return new BotWrapper(new AlwaysThrowsBot());
    }
  }

  public class BotWrapper : IBot, IRockPaperScissorsBot
  {
    readonly AlwaysThrowsBot _bot;

    public BotWrapper(AlwaysThrowsBot bot)
    {
      _bot = bot;
    }

    public Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules)
    {
      return _bot.MakeMove(you, opponent, rules);
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
