using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GameTemplate 
{

    public Player playGame(Board board, Player player)
    {
        // algoritme logica
        if (CheckEndCondition(board, player))
        {
            return GetWinner(board);
        }
        return playGame(board, MoveResult(board, player, DoTurn(board, player)));
    }

    public virtual Pit DoTurn(Board board, Player player) 
    {

        board.DrawBoard();

        Console.WriteLine(player.PlayerName + " Choose a number to pick a non-empty pit:");


        //We first need to check if a player chooses a valid number, aka plays from their pits.
        string? chooseNumber = Console.ReadLine();
        if (int.TryParse(chooseNumber, out int chosenNumber))
        {
            if (chosenNumber <= 0)
            {
                Console.WriteLine("Invalid option");
                return DoTurn(board, player);
            }
            else if (chosenNumber > (board.Pits.Length - 2) / 2)
            {
                Console.WriteLine("Invalid option");
                return DoTurn(board, player);
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
                Console.WriteLine("Can't choose a pit with zero stones");
                return DoTurn(board, player);
            }

            return board.MoveStones(chosenNumber, player.PlayerNumb);
        }
        else
        {
            Console.WriteLine("Invalid option");
            return DoTurn(board, player);
        }
    }
    public abstract Player MoveResult(Board board, Player player, Pit EndPit);
    public virtual bool CheckEndCondition(Board board, Player player) 
    {
        foreach (Pit pit in board.Pits.Where(n => n.IsHomePit == false && n.GetOwner() == player.PlayerNumb))
        {
            if (pit.GetStoneAmount() != 0)
                return false;
        }
        Console.WriteLine(Game.gameSettings.GetPlayer(Player.Numb.P1).PlayerName + ": " + board.GetHomePit(Player.Numb.P1).GetStoneAmount() + " - " + Game.gameSettings.GetPlayer(Player.Numb.P2).PlayerName + ": " + board.GetHomePit(Player.Numb.P2).GetStoneAmount());
        return true;
    }
    public virtual Player GetWinner(Board board) 
    {
        if (board.GetHomePit(Player.Numb.P1).GetStoneAmount() > board.GetHomePit(Player.Numb.P2).GetStoneAmount())
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P1);
        }
        else if (board.GetHomePit(Player.Numb.P1).GetStoneAmount() == board.GetHomePit(Player.Numb.P2).GetStoneAmount())
        {
            return Game.gameSettings.GetPlayer(Player.Numb.None); //It's a draw.
        }
        else
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P2);
        }
    }
}