﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    private UI ui = new UI();
    public GameSettings gameSettings;
    private GameTemplate gameTemplate;

    public enum Variant
    {
        Mancala,
        Wari,
        WarCali
    }

    //methode that starts the game by first asking the player for gamesettings and creating the template from those settings 
    public void StartGame()
    {
        gameSettings = GetGameSettings();
        gameTemplate = makeGameTemplate(gameSettings.gameVariant);
        Player winner = gameTemplate.playGame(gameSettings.GameBoard, gameSettings.player1, gameSettings);

        ui.DisplayMessage(gameSettings.GetPlayer(Player.Numb.P1).PlayerName + ": " + gameSettings.player1.score + " - " + gameSettings.GetPlayer(Player.Numb.P2).PlayerName + ": " + gameSettings.player2.score);
        ui.DisplayMessage(winner.PlayerName + " has won! Good Job!");
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
        bool preMadeSettings = ui.AskStandardOptions();
        if (preMadeSettings)
        {
            return (new GameSettings(gameVariant, player1Name, player2Name, true));
        }

        int pits = ui.AskPitAmount();
        int stones = ui.AskStoneAmount();

        return (new GameSettings(gameVariant, player1Name, player2Name, false, pits, stones));
    }
}

