using System;
using System.Diagnostics;
using System.Threading;

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
      DecisionClock<Move> clock = new DecisionClock<Move>(new TimeoutMove());
      Move move = clock.Run(() => _bot.MakeMove(this, opponent, rules));
      return new PlayerMove(this, move);
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

  public class DecisionClock<O>
  {
    readonly ManualResetEvent _stopWaiting = new ManualResetEvent(false);
    readonly O _timeoutValue;
    O _value;

    public DecisionClock(O timeoutValue)
    {
      _timeoutValue = timeoutValue;
      _value = timeoutValue;
    }

    public O Run(Func<O> func)
    {
      Thread thread = new Thread(Run);
      thread.Start(func);
      _stopWaiting.WaitOne(TimeSpan.FromMilliseconds(10));
      if (thread.IsAlive)
      {
        thread.Abort();
        return _timeoutValue;
      }
      return _value;
    }

    private void Run(object parameter)
    {
      _value = ((Func<O>)parameter)();
      _stopWaiting.Set();
    }
  }
}