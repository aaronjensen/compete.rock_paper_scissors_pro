using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissorsPro
{
  public class Game
  {
    readonly GameRules _rules;

    public Game(GameRules rules)
    {
      _rules = rules;
    }

    public GameResults Play(Player player1, Player player2)
    {
      player1.Reset(_rules);
      player2.Reset(_rules);

      var winDeterminer = new WinDeterminer();
      int pointValue = 1;
      int gameNumber = 0;

      while (player1.Points < _rules.PointsToWin && player2.Points < _rules.PointsToWin && gameNumber < _rules.MaximumGames)
      {
        var move1 = player1.MakeMove(player2, _rules);
        var move2 = player2.MakeMove(player1, _rules);

        var winner = winDeterminer.DetermineWinner(move1, move2);

        if (winner == null)
        {
          ++pointValue;
        }
        else
        {
          winner.AwardPoints(pointValue);
          pointValue = 1;
        }

        gameNumber++;
      }

      return new GameResults(player1, player2);
    }
  }

  public class GameResults
  {
    public GameResults(Player player1, Player player2)
    {
      Player1 = player1;
      Player2 = player2;

      if (player1.Points > player2.Points)
      {
        Winner = player1;
        Loser = player2;
      }
      else if (player1.Points < player2.Points)
      {
        Winner = player2;
        Loser = player1;
      }
      else
      {
        IsTie = true;
      }
    }

    public Player Winner { get; private set; }
    public Player Loser { get; private set; }
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }
    public bool IsTie { get; private set; }
  }
}
