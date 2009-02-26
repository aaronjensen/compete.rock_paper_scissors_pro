namespace RockPaperScissorsPro
{
  public interface IPlayer
  {
    int DynamiteRemaining { get; }
    bool HasDynamite { get; }
    int Points { get; }
  }

  public interface IBot
  {
    Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules);
  }

  public class Player : IPlayer
  {
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

    public virtual PlayerMove MakeMove()
    {
      throw new System.NotImplementedException();
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