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

    public Player playGame(Board board, Player player)
    {
        // algoritme logica
        if (CheckEndCondition(board, player))
        {
            return GetWinner(board);
        }
        chosenPitNumber = ChoosePit(board, player);
        lastPit = DoTurn(board, player, chosenPitNumber);
        playersTurn = MoveResult(board, player, lastPit, chosenPitNumber);
        return playGame(board, playersTurn);
    }
    public virtual int ChoosePit(Board board, Player player)
    {

        board.DrawBoard(Game.gameSettings.GetPlayer(Player.Numb.P1).score, Game.gameSettings.GetPlayer(Player.Numb.P2).score);

        ui.DisplayMessage(player.PlayerName + " Choose a number to pick a non-empty pit:");


        //We first need to check if a player chooses a valid number, aka plays from their pits.
        string? chooseNumber = Console.ReadLine();
        if (int.TryParse(chooseNumber, out int chosenNumber))
        {
            if (chosenNumber <= 0)
            {
                ui.DisplayMessage("Invalid option");
                return ChoosePit(board, player);
            }
            else if (chosenNumber > (board.Pits.Length - 2) / 2 && board.hasHomePit)
            {
                ui.DisplayMessage("Invalid option");
                return ChoosePit(board, player);
            }
            else if (chosenNumber > board.Pits.Length / 2 && !board.hasHomePit)
            {
                ui.DisplayMessage("Invalid Option");
                return ChoosePit(board, player);
            }
            else if (chosenNumber > board.Pits.Length / 2 && !board.hasHomePit)
            {
                ui.DisplayMessage("Invalid option");
                return ChoosePit(board, player);
            }


            if (player.PlayerNumb == Player.Numb.P1)
            {
                chosenNumber -= 1;
            }
            else
            {
                chosenNumber += (board.Pits.Length / 2) - 1;
            }

            if (board.Pits[chosenNumber].GetStoneAmount() == 0)
            {
                ui.DisplayMessage("Can't choose a pit with zero stones");
                return ChoosePit(board, player);
            }

            return chosenNumber; //board.MoveStones(chosenNumber, player.PlayerNumb);
        }
        else
        {
            ui.DisplayMessage("Invalid option");
            return ChoosePit(board, player);
        }
    }
    public virtual Pit DoTurn(Board board, Player player,int chosenNumber) 
    {
        return board.MoveStones(chosenNumber, player.PlayerNumb);
    }

    public abstract Player MoveResult(Board board, Player player, Pit EndPit, int chosenPitNumber);
    public virtual bool CheckEndCondition(Board board, Player player) 
    {
        foreach (Pit pit in board.Pits.Where(n => n.IsHomePit == false && n.GetOwner() == player.PlayerNumb))
        {
            if (pit.GetStoneAmount() != 0)
                return false;
        }
        ui.DisplayMessage(Game.gameSettings.GetPlayer(Player.Numb.P1).PlayerName + ": " + board.GetHomePit(Player.Numb.P1).GetStoneAmount() + " - " + Game.gameSettings.GetPlayer(Player.Numb.P2).PlayerName + ": " + board.GetHomePit(Player.Numb.P2).GetStoneAmount());
        return true;
    }
    public virtual Player GetWinner(Board board) 
    {
        if (Game.gameSettings.player1.score > Game.gameSettings.player2.score)
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P1);
        }
        else if (Game.gameSettings.player1.score == Game.gameSettings.player2.score)
        {
            return new Player("Nobody", Player.Numb.P1); //It's a draw.
        }
        else
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P2);
        }
    }
}