namespace RockPaperScissorsPro
{
  public interface IRockPaperScissorsBot
  {
    Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules);
  }
}