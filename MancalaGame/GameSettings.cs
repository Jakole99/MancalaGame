using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameSettings
{
    private Player player1;
    private Player player2;
    public Board GameBoard;

    public GameSettings()
    {

    }

    public Player GetPlayer(Player.Numb playerNumb)
    {
        if (playerNumb == Player.Numb.P1)
            return player1;
        else
            return player2;
    }

    private void makePlayers(string player1Name, string player2Name)
    {
        player1 = new Player(player1Name, Player.Numb.P1);

        player2 = new Player(player2Name, Player.Numb.P2);
    }

    private void makeBoard(int pits, int stones, Game.Variant variant)
    {
        BoardFactory boardFactory = new BoardFactory();
        GameBoard = boardFactory.GetBoard(pits, stones, variant);
    }
}

