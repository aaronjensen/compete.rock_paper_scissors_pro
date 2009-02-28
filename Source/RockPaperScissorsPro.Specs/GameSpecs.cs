using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace RockPaperScissorsPro.Specs
{
  public class when_playing_a_game_between_a_rocker_and_a_paperer
    : GameSpecs
  {
    Establish context = () =>
    {
      player1 = new PlayerThatAlwaysThrows(Round1Move.Rock);
      player2 = new PlayerThatAlwaysThrows(Round1Move.Paper);
    };

    Because of = () =>
      result = game.Play(player1, player2);

    It should_declare_the_paperer_the_winner = () =>
      result.Winner.ShouldBeTheSameAs(player2);

    It should_declare_the_rocker_the_loser = () =>
      result.Loser.ShouldBeTheSameAs(player1);

    It should_declare_that_it_is_not_a_tie = () =>
      result.IsTie.ShouldBeFalse();
  }

  public class when_playing_a_game_between_a_rocker_and_a_another_rocker
    : GameSpecs
  {
    Establish context = () =>
    {
      player1 = new PlayerThatAlwaysThrows(Round1Move.Rock);
      player2 = new PlayerThatAlwaysThrows(Round1Move.Rock);
    };

    Because of = () =>
      result = game.Play(player1, player2);

    It should_declare_no_winner = () =>
      result.Winner.ShouldBeNull();

    It should_declare_no_loser = () =>
      result.Loser.ShouldBeNull();

    It should_declare_a_tie = ()=>
      result.IsTie.ShouldBeTrue();
  }

  class PlayerThatAlwaysThrows
    : Player
  {
    readonly Move _move;

    public PlayerThatAlwaysThrows(Move move)
      : base("dumb", new DumbBot(move))
    {
      _move = move;
    }

    public override string ToString()
    {
      return "I throw " + _move.GetType().Name;
    }
  }

  public class GameSpecs
  {
    protected static Game game;
    protected static Player player1;
    protected static Player player2;
    protected static GameResults result;

    Establish context = () =>
    {
      var gameRules = new GameRules();
      gameRules.PointsToWin = 1000;
      gameRules.MaximumGames = 5000;
      gameRules.StartingDynamite = 100;
      game = new Game(gameRules);
    };
  }
}
