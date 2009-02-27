using Compete.Bot;

namespace RockPaperScissorsPro
{
  public interface IRockPaperScissorsBot : IBot
  {
    Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules);
  }
}