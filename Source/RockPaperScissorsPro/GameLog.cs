using System;
using System.Text;

namespace RockPaperScissorsPro
{
  public class GameLog
  {
    readonly Player _player1;
    readonly Player _player2;
    StringBuilder builder = new StringBuilder();
    public GameLog(Player player1, Player player2)
    {
      _player1 = player1;
      _player2 = player2;
      builder.AppendLine(String.Format("BEGIN: {0} {1} - {2}", player1.TeamName, player2.TeamName, DateTime.Now));
    }

    public void AfterMove(Player player1, Player player2)
    {
      builder.AppendLine(String.Format("MOVE:  {0} {1}  SCORE: {2}-{3}", player1.LastMove, player2.LastMove, player1.Points, player2.Points));
    }

    public void EndMatch()
    {
      builder.AppendLine(String.Format("END:   {0} {1} - {2}", _player1.TeamName, _player2.TeamName, DateTime.Now));
    }

    public string GetLog()
    {
      return builder.ToString();
    }
  }
}