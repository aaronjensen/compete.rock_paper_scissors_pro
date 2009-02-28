using System;

namespace RockPaperScissorsPro
{
  public interface IPlayer
  {
    string TeamName { get; }
    int DynamiteRemaining { get; }
    bool HasDynamite { get; }
    int Points { get; }
    int NumberOfDecisions { get; }
    TimeSpan TotalTimeDeciding { get; }
    Move LastMove { get; }
  }
}