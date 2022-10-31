using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameSettings
{
    public Player player1 { get; private set; }
    public Player player2 { get; private set; }
    public Board GameBoard;
    public Game.Variant gameVariant{ get; private set;}

    public GameSettings(int pits, int stones, Game.Variant gameVariant, string player1Name, string player2Name)
    {
        this.gameVariant = gameVariant;
        makePlayers(player1Name, player2Name);
        makeBoard(pits, stones, gameVariant);
    }

    public Player GetPlayer(Player.Numb playerNumb)
    {
        if (playerNumb == Player.Numb.P1)
            return player1;
        else
            return player2;
    }

    public Player NextPlayer(Player.Numb playerNumb)
    {
        if (playerNumb == Player.Numb.P1)
            return player2;
        else
            return player1;
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

