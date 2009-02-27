namespace RockPaperScissorsPro
{
  public interface IPlayer
  {
    int DynamiteRemaining { get; }
    bool HasDynamite { get; }
    int Points { get; }
  }

  public class Player : IPlayer
  {
    readonly IBot _bot;

    public Player(IBot bot)
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