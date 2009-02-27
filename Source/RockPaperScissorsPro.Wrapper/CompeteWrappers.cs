using System;
using System.Collections.Generic;

using Compete.Model.Game;

namespace RockPaperScissorsPro
{
  public class CompeteGameWrapper : IGame
  {
    public GameResult Play(BotPlayer player1, BotPlayer player2)
    {
      IRockPaperScissorsBot wrappedPlayer1 = player1.Bot as IRockPaperScissorsBot;
      IRockPaperScissorsBot wrappedPlayer2 = player2.Bot as IRockPaperScissorsBot;
      if (wrappedPlayer1 == null && wrappedPlayer2 == null) return GameResult.Tie(player1, player2);
      if (wrappedPlayer1 == null) return GameResult.WinnerAndLoser(player2, player1);
      if (wrappedPlayer2 == null) return GameResult.WinnerAndLoser(player1, player2);

      Player rpsPlayer1 = new Player(wrappedPlayer1);
      Player rpsPlayer2 = new Player(wrappedPlayer2);

      Game game = new Game(GameRules.Default);
      GameResults gameResults = game.Play(rpsPlayer1, rpsPlayer2);
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
        return GameResult.Tie(map(gameResults.Player1), map(gameResults.Player1));
      }
      BotPlayer winner = map(gameResults.Winner);
      BotPlayer loser = map(gameResults.Loser);
      return GameResult.WinnerAndLoser(winner, loser);
    }
  }
}
