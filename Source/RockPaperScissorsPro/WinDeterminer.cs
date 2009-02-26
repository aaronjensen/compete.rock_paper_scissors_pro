namespace RockPaperScissorsPro.Specs
{
  public class WinDeterminer
  {
    public Player DetermineWinner(PlayerMove player1Move, PlayerMove player2Move)
    {
      if (player1Move.Move is DynamiteMove && !player1Move.Player.HasDynamite)
      {
        player1Move = new PlayerMove(player1Move.Player, new IllegalMove());
      }

      if (player2Move.Move is DynamiteMove && !player2Move.Player.HasDynamite)
      {
        player2Move = new PlayerMove(player2Move.Player, new IllegalMove());
      }

      if (player1Move.Move.CanBeat(player2Move.Move))
      {
        return player1Move.Player;
      }

      if (player2Move.Move.CanBeat(player1Move.Move))
      {
        return player2Move.Player;
      }

      return null;
    }
  }
}