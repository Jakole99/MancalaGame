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

    //methode that starts the game by first asking the player for gamesettings and creating the template from those settings 
    public void StartGame()
    {
        gameSettings = GetGameSettings();
        gameTemplate = makeGameTemplate(gameSettings.gameVariant);
        Player winner = gameTemplate.playGame(gameSettings.GameBoard, gameSettings.player1);
        Console.WriteLine(winner.PlayerName + " has won! Good Job!");
    }

    private GameTemplate makeGameTemplate(Variant gameVariant)
    {
        GameTemplateFactory gameTemplateFactory = new GameTemplateFactory();
        return gameTemplateFactory.GetGameTemplate(gameVariant);                   
    }


    private GameSettings GetGameSettings()
    {
        string player1Name = ui.AskPlayerName();
        string player2Name = ui.AskPlayerName();

        Variant gameVariant = ui.AskGameVariant();
        bool preMadeSettings = ui.AskStanderdOptions();
        if (preMadeSettings)
        {
            return (new GameSettings(0, 0, gameVariant, player1Name, player2Name));
        }

        int pits = ui.AskPitAmount();
        int stones = ui.AskStoneAmount();

        return (new GameSettings(pits, stones, gameVariant, player1Name, player2Name));
    }
}

