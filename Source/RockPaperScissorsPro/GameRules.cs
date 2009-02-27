using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissorsPro
{
  public class GameRules
  {
    public static GameRules Default = new GameRules() { MaximumGames = 5000, PointsToWin = 1000, StartingDynamite = 100 };

    public int MaximumGames { get; set; }
    public int PointsToWin { get; set; }
    public int StartingDynamite { get; set; }
  }
}
