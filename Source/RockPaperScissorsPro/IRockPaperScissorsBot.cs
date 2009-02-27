namespace RockPaperScissorsPro
{
  public interface IRockPaperScissorsBot : Compete.Model.Game.IBot
  {
    Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules);
  }
}