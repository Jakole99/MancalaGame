﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MancalaTemplate : GameTemplate
{
    int middleOfTheBoard = (Game.gameSettings.GameBoard.Pits.Length - 1) / 2; //the first nyumba is the middle element of the Pit array, and the second nyumba is the last element
    int endOfTheBoard = (Game.gameSettings.GameBoard.Pits.Length - 1);

    public override bool CheckEndCondition(Board board)
    {
       foreach (Pit pit in board.Pits.Where(n => n.IsHomePit == false))
       {
            if (pit.GetStoneAmount() != 0)
                return false;
       }
       return true;
    }

    public override Player GetWinner(Board board)
    {

        if (board.Pits[middleOfTheBoard].GetStoneAmount() > board.Pits[endOfTheBoard].GetStoneAmount())
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P1);
        }
        else if (board.Pits[middleOfTheBoard].GetStoneAmount() == board.Pits[endOfTheBoard].GetStoneAmount())
        {
            return Game.gameSettings.GetPlayer(Player.Numb.None); //It's a draw.
        }
        else
        {
            return Game.gameSettings.GetPlayer(Player.Numb.P2);
        }
    }

    public override Pit DoTurn(Board board, Player player) 
    {
        Console.WriteLine("Choose a number to pick a non-empty pit:");


        
        int chosenNumber = Convert.ToInt32(Console.ReadLine());
        Pit EndPit = null;

        //We first need to check if a player chooses a valid number, aka plays from their pits.
        if (chosenNumber < 0)
        {
            Console.WriteLine("Invalid option");
            DoTurn(board, player);
        }
        else if (player == Game.gameSettings.GetPlayer(Player.Numb.P1) && chosenNumber > middleOfTheBoard)
        {
            Console.WriteLine("Invalid option");
            DoTurn(board, player);
        }
        else if (player == Game.gameSettings.GetPlayer(Player.Numb.P2) && chosenNumber < middleOfTheBoard || chosenNumber > endOfTheBoard)
        {
            Console.WriteLine("Invalid option");
            DoTurn(board, player);
        }
        else 
        { 
            EndPit = board.MoveStones(chosenNumber, player.PlayerNumb); 
        }

        return EndPit;
        
    }

    public override Player MoveResult(Board board, Player player, Pit EndPit)
    {

        ///Now we can move the stones correclty.
        //board.MoveStones(chosenNumber, player.PlayerNumb); wordt al gedaan bij doTurn.

        ///Now we check what happens next, what is the result of that move which has been played.

        ///Last Stone ends in Nyumba of the player. Player can play again.
        if (EndPit.IsHomePit == true) 
        {
            return player;
        }


        ///Last Stone ends in an empty pit
        if (EndPit.GetStoneAmount() == 0)
        {
            /// Its the players pit
            if (EndPit.GetOwner() == player.PlayerNumb)
            {
                                              ///Last Stone ends in an empty Pit of the player and the opposite pit of the opponent is not empty
                                              ///, player grabs all stones from these two pits and collects them in their Nyumba.
                                              

                                              ///Last Stone ends in an empty Pit of the player and the opposite pit of the opponent is empty
                                              ///, next players turn.
            }
            /// Its the opponents pit
            else
            {
                //return player.Next();         ///Last Stone ends in an empty Pit of the opponent. Next players turn.
            }

        }

        return null;
        ///Player has no more stones left in their regular pits.
        //al gedaan bij CheckEndCondition
        ///Player with the most stones.
        //al gedaan by GetWinner

    }
}