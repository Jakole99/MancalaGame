using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{

    static public GameSettings gameSettings;
    public enum Variant
    {
        Mancala,
        Wari,
        WarCali
    }

    public Game()
    {
        
    }

    public void StartGame()
    {
        GetGameSettings();
    }

    public void GetGameSettings()
    {
        int pits = Int32.Parse(Console.ReadLine());
        int stones = Int32.Parse(Console.ReadLine());

        Game.Variant gamevariant;
        int variant = Int32.Parse(Console.ReadLine());
        if (variant == 1)
            gamevariant = Game.Variant.Mancala;
        else
            return;

        string player1name = Console.ReadLine();
        string player2name = Console.ReadLine();


        gameSettings = new GameSettings(pits, stones, gamevariant, player1name, player2name);
    }

    
}

