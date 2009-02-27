namespace RockPaperScissorsPro
{
  public interface IPlayer : Compete.Model.Game.IBot
  {
    int DynamiteRemaining { get; }
    bool HasDynamite { get; }
    int Points { get; }
  }

  public class Player : IPlayer
  {
    readonly IRockPaperScissorsBot _bot;

    public IRockPaperScissorsBot Bot
    {
      get { return _bot; }
    }

    public Player(IRockPaperScissorsBot bot)
    {
      _bot = bot;
    }

    public int DynamiteRemaining
    {
      get; private set;
    }

    public bool HasDynamite
    {
      get { return DynamiteRemaining > 0; }
    }

    public int Points
    {
      get; private set;
    }

    public virtual PlayerMove MakeMove(IPlayer opponent, GameRules rules)
    {
      return new PlayerMove(this, _bot.MakeMove(this, opponent, rules));
    }

    public void Reset(GameRules rules)
    {
      Points = 0;
      DynamiteRemaining = rules.StartingDynamite;
    }

    public void AwardPoints(int points)
    {
      Points += points;
    }

    public void UseDynamite()
    {
      DynamiteRemaining--;
    }
  }
}