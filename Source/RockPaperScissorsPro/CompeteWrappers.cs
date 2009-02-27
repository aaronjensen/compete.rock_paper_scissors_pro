using System;
using System.Collections.Generic;

using Compete.Model.Game;

namespace RockPaperScissorsPro
{
  public class CompeteGameWrapper : IGame
  {
    public GameResult Play(Compete.Model.Game.IPlayer player1, Compete.Model.Game.IPlayer player2)
    {
      CompetePlayerWrapper wrappedPlayer1 = player1 as CompetePlayerWrapper;
      CompetePlayerWrapper wrappedPlayer2 = player2 as CompetePlayerWrapper;
      if (wrappedPlayer1 == null && wrappedPlayer2 == null) return GameResult.Tie(player1, player2);
      if (wrappedPlayer1 == null) return GameResult.WinnerAndLoser(player2, player1);
      if (wrappedPlayer2 == null) return GameResult.WinnerAndLoser(player1, player2);

      Game game = new Game(GameRules.Default);
      GameResults gameResults = game.Play(wrappedPlayer1.Player, wrappedPlayer2.Player);
      return gameResults.ToGameResult(wrappedPlayer1, wrappedPlayer2);
    }
  }

  public static class Mappings
  {
    public static GameResult ToGameResult(this GameResults gameResults, CompetePlayerWrapper player1, CompetePlayerWrapper player2)
    {
      if (gameResults.IsTie)
      {
        return GameResult.Tie(player1, player2);
      }
      Compete.Model.Game.IPlayer winner = gameResults.Winner == player1.Player ? player1 : player2;
      Compete.Model.Game.IPlayer loser = gameResults.Loser == player1.Player ? player1 : player2;
      return GameResult.WinnerAndLoser(winner, loser);
    }
  }

  public class CompetePlayerWrapper : Compete.Model.Game.IPlayer
  {
    readonly IBot _bot;
    readonly Player _player;

    public Player Player
    {
      get { return _player; }
    }

    public CompetePlayerWrapper(IBot bot)
    {
      _bot = bot;
      _player = new Player(_bot);
    }
  }
}
