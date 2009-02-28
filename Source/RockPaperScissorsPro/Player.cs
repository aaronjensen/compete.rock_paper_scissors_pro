using System;
using System.Diagnostics;
using System.Threading;

namespace RockPaperScissorsPro
{
  public class Player : IPlayer
  {
    readonly string _teamName;
    readonly IRockPaperScissorsBot _bot;

    public IRockPaperScissorsBot Bot
    {
      get { return _bot; }
    }

    public Player(string teamName, IRockPaperScissorsBot bot)
    {
      _teamName = teamName;
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

    public string TeamName
    {
      get { return _teamName; }
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

    public virtual PlayerMove GetMoveToMake(IPlayer opponent, GameRules rules, IGameLog log)
    {
      var clock = new DecisionClock<Move>(new TimeoutMove());

      var us = new ImmutablePlayer(this);
      var them = new ImmutablePlayer(opponent);

      Move move = clock.Run(() => _bot.MakeMove(us, them, rules, log));

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

  public class ImmutablePlayer : IPlayer
  {
    public ImmutablePlayer(IPlayer player)
    {
      TeamName = player.TeamName;
      DynamiteRemaining = player.DynamiteRemaining;
      HasDynamite = player.HasDynamite;
      Points = player.Points;
      NumberOfDecisions = player.NumberOfDecisions;
      TotalTimeDeciding = player.TotalTimeDeciding;
      LastMove = player.LastMove;
    }

    public string TeamName { get; private set; }
    public int DynamiteRemaining { get; private set; }
    public bool HasDynamite { get; private set; }
    public int Points { get; private set; }
    public int NumberOfDecisions { get; private set; } 
    public TimeSpan TotalTimeDeciding { get; private set; } 
    public Move LastMove { get; private set; } 
  }

  public class DecisionClock<O> where O : class
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
      _value = null;
    }

    public O Run(Func<O> func)
    {
      Thread thread = new Thread(Run);
      thread.Priority = ThreadPriority.AboveNormal;
      _value = null;
      _sw.Start();
      thread.Start(func);
      _stopWaiting.WaitOne(TimeSpan.FromMilliseconds(5));
      _sw.Stop();

      if (_value == null)
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