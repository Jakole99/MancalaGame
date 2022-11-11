using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameSettings
{
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }
    public Board GameBoard;
    public Game.Variant GameVariant{ get; private set;}

    public GameSettings(Game.Variant gameVariant, string player1Name, string player2Name, bool standard, int pits = 8, int stones = 4)
    {
        this.GameVariant = gameVariant;
        MakePlayers(player1Name, player2Name);
        MakeBoard(pits, stones, gameVariant, standard);
    }

    public Player GetPlayer(Player.Numb playerNumb)
    {
        if (playerNumb == Player.Numb.P1)
            return Player1;
        else
            return Player2;
    }

    public Player NextPlayer(Player.Numb playerNumb)
    {
        if (playerNumb == Player.Numb.P1)
            return Player2;
        else
            return Player1;
    }

    private void MakePlayers(string player1Name, string player2Name)
    {
        Player1 = new Player(player1Name, Player.Numb.P1);

        Player2 = new Player(player2Name, Player.Numb.P2);
    }

    private void MakeBoard(int pits, int stones, Game.Variant variant, bool standerd)
    {
        BoardFactory boardFactory = new BoardFactory();
        if (standerd)
        {
            GameBoard = boardFactory.GetStandardBoard(variant);
        }
        else
        {
            GameBoard = boardFactory.GetCustomBoard(pits, stones, variant);
        } 
    }
}

