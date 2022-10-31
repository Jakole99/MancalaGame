using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    private UI ui = new UI();
    static public GameSettings gameSettings;
    private GameTemplate gameTemplate;

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
        gameSettings = GetGameSettings();
        gameTemplate = GetGameTemplate(gameSettings.gameVariant);
        gameTemplate.playGame(gameSettings.GameBoard, gameSettings.player1);
    }

    private GameTemplate GetGameTemplate(Variant gameVariant)
    {
        if (gameVariant == Variant.Mancala)
            return (new MancalaTemplate());
        else if (gameVariant == Variant.Wari)
            return null;
        else
            return null;

    }
    

    private GameSettings GetGameSettings()
    {
        string player1Name = ui.AskPlayerName();
        string player2Name = ui.AskPlayerName();

        Variant gameVariant = ui.AskGameVariant();
        int pits = ui.AskPitAmount();
        int stones = ui.AskStoneAmount();

        return (new GameSettings(pits, stones, gameVariant, player1Name, player2Name));
    }

    
}

