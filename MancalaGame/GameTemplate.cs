using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GameTemplate 
{
    Pit lastPit;
    Player playersTurn;
    UI ui = new UI();
    int chosenPitNumber;

    //The template method, using recursion to keep the game running.
    public Player playGame(Player player, GameSettings gameSettings)
    {
        if (CheckEndCondition(gameSettings.GameBoard, player))
        {
            return GetWinner(gameSettings);
        }
        chosenPitNumber = ChoosePit(player, ui, gameSettings);
        lastPit = DoTurn(gameSettings.GameBoard, player, chosenPitNumber);
        playersTurn = MoveResult(player, lastPit, chosenPitNumber, gameSettings);
        return playGame(playersTurn, gameSettings);
    }
   
    //Keep asking the player to pick a pit to play from, until it is a valid number. A player cannot play from empty or opponents pit.
    public virtual int ChoosePit(Player player, UI ui, GameSettings gameSettings)
    {
        gameSettings.GameBoard.DrawBoard(gameSettings.GetPlayer(Player.Numb.P1).score, gameSettings.GetPlayer(Player.Numb.P2).score); 
        ui.DisplayMessage(player.PlayerName + " Choose a number to pick a non-empty pit:");

        int chosenNumber = ui.GetInteger();

        if (InValidChosenNumber(gameSettings.GameBoard, chosenNumber))
        {
            ui.DisplayMessage("Invalid option");
            return ChoosePit(player, ui, gameSettings);
        }

        chosenNumber += AdaptPlayerChoice(gameSettings.GameBoard, player);

        if (gameSettings.GameBoard.Pits[chosenNumber].GetStoneAmount() == 0)
        {
            ui.DisplayMessage("Can't choose a pit with zero stones");
            return ChoosePit(player, ui, gameSettings);
        }

        return chosenNumber;
    }


    //Player chooses a valid number which has been given on the screen.
    public bool InValidChosenNumber(Board board, int chosenNumber)
    {
        if (chosenNumber <= 0)
        {
            return true;
        }

        if (chosenNumber > (board.Pits.Length - 2) / 2 && board.HasHomePit)
        {
            return true;
        }

        if (chosenNumber > board.Pits.Length / 2 && !board.HasHomePit)
        {
            return true;
        }

        return false;
    }

    //Depending on which player chooses, the index of the pit in the list will be different.
    public int AdaptPlayerChoice(Board board, Player player)
    {
        if (player.PlayerNumb == Player.Numb.P1)
        {
            return (-1);
        }

        return (board.Pits.Length / 2) - 1;
    }

    public virtual Pit DoTurn(Board board, Player player,int chosenNumber) 
    {
        return board.MoveStones(chosenNumber, player.PlayerNumb);
    }

    public abstract Player MoveResult(Player player, Pit EndPit, int chosenPitNumber, GameSettings gameSettings);
    public virtual bool CheckEndCondition(Board board, Player player) 
    {
        foreach (Pit pit in board.Pits.Where(n => n.IsHomePit == false && n.GetOwner() == player.PlayerNumb))
        {
            if (pit.GetStoneAmount() != 0)
                return false;
        }
        
        return true;
    }
    public virtual Player GetWinner(GameSettings gameSettings) 
    {
        if (gameSettings.Player1.score > gameSettings.Player2.score)
        {
            return gameSettings.GetPlayer(Player.Numb.P1);
        }
        else if (gameSettings.Player1.score == gameSettings.Player2.score)
        {
            return new Player("Nobody", Player.Numb.None);
        }
        else
        {
            return gameSettings.GetPlayer(Player.Numb.P2);
        }
    }
}