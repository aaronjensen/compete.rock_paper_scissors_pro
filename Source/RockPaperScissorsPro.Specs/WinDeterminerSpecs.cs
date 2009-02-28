using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace RockPaperScissorsPro.Specs
{
  public class when_both_players_throw_rock
    : WinDeterminerSpecs
  {
    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, rock), new PlayerMove(player2, rock));

    It should_not_declare_a_winner = () =>
      winner.ShouldBeNull();
  }

  public class when_rock_fights_paper
    : WinDeterminerSpecs
  {
    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, rock), new PlayerMove(player2, paper));

    It should_declare_paper_the_winner =()=>
      winner.ShouldBeTheSameAs(player2);
  }

  public class when_rock_fights_scissors
    : WinDeterminerSpecs
  {
    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, rock), new PlayerMove(player2, scissors));

    It should_declare_rock_the_winner =()=>
      winner.ShouldBeTheSameAs(player1);
  }

  public class when_dynamite_fights_scissors
    : WinDeterminerSpecs
  {
    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, dynamite), new PlayerMove(player2, scissors));

    It should_declare_dynamite_the_winner =()=>
      winner.ShouldBeTheSameAs(player1);
  }

  public class when_water_fights_dynamite
    : WinDeterminerSpecs
  {
    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, dynamite), new PlayerMove(player2, water));

    It should_declare_water_the_winner =()=>
      winner.ShouldBeTheSameAs(player2);
  }

  public class when_dynamite_fights_rock_but_the_player_has_no_dynamite_remaining
    : WinDeterminerSpecs
  {
    Establish context = () =>
    {
      player1.UseDynamite();
    };

    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, dynamite), new PlayerMove(player2, rock));

    It should_declare_rock_the_winner =()=>
      winner.ShouldBeTheSameAs(player2);
  }

  public class when_dynamite_fights_dynamite_but_one_player_is_out_of_dynamite
    : WinDeterminerSpecs
  {
    Establish context = () =>
    {
      player1.UseDynamite();
    };

    Because of = () =>
      winner = winDeterminer.DetermineWinner(new PlayerMove(player1, dynamite), new PlayerMove(player2, dynamite));

    It should_declare_the_player_with_dynamite_the_winner =()=>
      winner.ShouldBeTheSameAs(player2);
  }

  public class WinDeterminerSpecs
  {
    protected static Player player1;
    protected static Player player2;
    protected static Move rock;
    protected static Move paper;
    protected static Move scissors;
    protected static Move dynamite;
    protected static Move water;
    protected static WinDeterminer winDeterminer;
    protected static Player winner;

    Establish context = () =>
    {
      var gameRules = new GameRules();
      gameRules.StartingDynamite = 1;
      player1 = new Player("dumb", new DumbBot(Move.Rock));
      player2 = new Player("dumb", new DumbBot(Move.Rock));

      player1.Reset(gameRules);
      player2.Reset(gameRules);

      rock = Move.Rock;
      paper = Move.Paper;
      scissors = Move.Scissors;
      dynamite = ProMove.Dynamite;
      water = new WaterBalloonMove();
      winDeterminer = new WinDeterminer();
    };
  }

  public class DumbBot : IRockPaperScissorsBot
  {
    private readonly Move _move;

    public DumbBot(Move move)
    {
      _move = move;
    }

    public Move MakeMove(IPlayer you, IPlayer opponent, GameRules rules)
    {
      return _move;
    }
  }
}
