namespace RockPaperScissorsPro
{
  public class PlayerMove
  {
    public Player Player { get; private set; }
    public Move Move { get; private set; }

    public PlayerMove(Player player, Move move)
    {
      Player = player;
      Move = move;
    }
  }
}