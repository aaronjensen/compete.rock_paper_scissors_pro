using System;
using System.Collections.Generic;

using Compete.Model.Game;

namespace RockPaperScissorsPro
{
  public class CompeteGameWrapper : IGame
  {
    public GameResult Play(BotPlayer player1, BotPlayer player2)
    {
      var wrappedPlayer1 = player1.Bot as IRockPaperScissorsBot;
      var wrappedPlayer2 = player2.Bot as IRockPaperScissorsBot;
      if (wrappedPlayer1 == null && wrappedPlayer2 == null) return GameResult.Tie(player1, player2, "Neither player is an IRockPaperScissorsBot");
      if (wrappedPlayer1 == null) return GameResult.WinnerAndLoser(player2, player1, player1.TeamName + " is not an IRockPaperScissorsBot");
      if (wrappedPlayer2 == null) return GameResult.WinnerAndLoser(player1, player2, player1.TeamName + " is not an IRockPaperScissorsBot");

      var rpsPlayer1 = new Player(player1.TeamName, wrappedPlayer1);
      var rpsPlayer2 = new Player(player2.TeamName, wrappedPlayer2);

      var game = new Game(GameRules.Default);
      var gameResults = game.Play(rpsPlayer1, rpsPlayer2);
      return gameResults.ToGameResult((x) => {
        if (x == rpsPlayer1) return player1;
        if (x == rpsPlayer2) return player2;
        throw new InvalidOperationException("You've discovered a bug, you get 50 points.");
      });
    }
  }

  public static class Mappings
  {
    public static GameResult ToGameResult(this GameResults gameResults, Func<Player, BotPlayer> map)
    {
      if (gameResults.IsTie)
      {
        return GameResult.Tie(map(gameResults.Player1), map(gameResults.Player1), gameResults.Log);
      }
      BotPlayer winner = map(gameResults.Winner);
      BotPlayer loser = map(gameResults.Loser);
      return GameResult.WinnerAndLoser(winner, loser, gameResults.Log);
    }
  }
}
