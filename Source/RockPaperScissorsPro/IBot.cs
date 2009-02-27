namespace RockPaperScissorsPro
{
  public interface IBot
  {
    Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules);
  }
}