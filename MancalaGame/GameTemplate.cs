using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class GameTemplate 
{
    Pit lastPit;
    Player playersTurn;
    int chosenPitNumber;

    public Player playGame(Board board, Player player)
    {
        if (CheckEndCondition(board, player))
        {
            return GetWinner(board);
        }
        chosenPitNumber = ChoosePit(board, player);
        lastPit = DoTurn(board, player, chosenPitNumber);
        playersTurn = MoveResult(board, player, lastPit, chosenPitNumber);
        return playGame(board, playersTurn);
    }
   
    //Keep asking the player to pick a pit to play from, until it is a valid number. A player cannot play from empty or opponents pit.
    public virtual int ChoosePit(Board board, Player player)
    {

        board.DrawBoard(Game.gameSettings.GetPlayer(Player.Numb.P1).score, Game.gameSettings.GetPlayer(Player.Numb.P2).score); 
        Console.WriteLine(player.PlayerName + " Choose a number to pick a non-empty pit:");


        string? chooseNumber = Console.ReadLine();
        if (int.TryParse(chooseNumber, out int chosenNumber))
        {

            if (InValidChosenNumber(board, chosenNumber))
            {
                Console.WriteLine("Invalid option");
                return ChoosePit(board, player);
            }


            chosenNumber += AdaptPlayerChoice(board, player);


            if (board.Pits[chosenNumber].GetStoneAmount() == 0)
            {
                Console.WriteLine("Can't choose a pit with zero stones");
                return ChoosePit(board, player);
            }

            return chosenNumber;
        }

        Console.WriteLine("Invalid option");
        return ChoosePit(board, player);
    }

    //Player chooses a valid number which has been given.
    public bool InValidChosenNumber(Board board, int chosenNumber)
    {
        if (chosenNumber <= 0)
        {
            return true;
        }

        if (chosenNumber > (board.Pits.Length - 2) / 2 && board.hasHomePit)
        {
            return true;
        }

        if (chosenNumber > board.Pits.Length / 2 && !board.hasHomePit)
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

    public abstract Player MoveResult(Board board, Player player, Pit EndPit, int chosenPitNumber);
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
        if (Game.gameSettings.player1.score > Game.gameSettings.player2.score)
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P1);
        }
        else if (Game.gameSettings.player1.score == Game.gameSettings.player2.score)
        {
            return new Player("Nobody", Player.Numb.None); //It's a draw.
        }
        else
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P2);
        }
    }
}