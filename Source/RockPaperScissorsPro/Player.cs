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
    int NumberOfDecisions { get; }
    TimeSpan TotalTimeDeciding { get; }
    Move LastMove { get; }
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

    public TimeSpan TotalTimeDeciding
    {
      get; private set;
    }

    public int NumberOfDecisions
    {
      get; private set;
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

    public Move LastMove
    {
      get; private set;
    }

    public virtual PlayerMove GetMoveToMake(IPlayer opponent, GameRules rules)
    {
      DecisionClock<Move> clock = new DecisionClock<Move>(new TimeoutMove());
      Move move = clock.Run(() => _bot.MakeMove(this, opponent, rules));
      TotalTimeDeciding += clock.TimeToDecide;
      NumberOfDecisions++;
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

    public void SetLastMove(PlayerMove move)
    {
      LastMove = move.Move;
    }
  }

  public class DecisionClock<O>
  {
    readonly ManualResetEvent _stopWaiting = new ManualResetEvent(false);
    readonly O _timeoutValue;
    readonly Stopwatch _sw = new Stopwatch();
    O _value;

    public TimeSpan TimeToDecide
    {
      get { return _sw.Elapsed; }
    }

    public DecisionClock(O timeoutValue)
    {
      _timeoutValue = timeoutValue;
      _value = timeoutValue;
    }

    public O Run(Func<O> func)
    {
      Thread thread = new Thread(Run);
      _sw.Start();
      thread.Start(func);
      _stopWaiting.WaitOne(TimeSpan.FromMilliseconds(5));
      _sw.Stop();
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