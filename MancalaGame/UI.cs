using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI
{
    public UI()
    {

    }

    public string AskPlayerName()
    {
        Console.WriteLine("Please enter a username");

        return (Console.ReadLine());
    }

    public int AskPitAmount()
    {
        Console.WriteLine("Please enter an amount of pits greater 2 you would like to use:");
        
        string? pitAmountString = Console.ReadLine();
        if (pitAmountString == null)
        {
            Console.WriteLine("nothing is not a number");
            return AskPitAmount();
        }
        else
        {
            int pitAmount;
            if (int.TryParse(pitAmountString, out pitAmount))
            {
                if (pitAmount > 3 && pitAmount % 2 == 0)
                {
                    return pitAmount;
                }
                else
                {
                    Console.WriteLine("invalid number, try again");
                    return AskPitAmount();
                }
            }
            else
            {
                Console.WriteLine("this is not a number, try again");
                return AskPitAmount();
            }
        }
    }

    public int AskStoneAmount()
    {
        Console.WriteLine("Please enter the amount of stones you would like to be added to each pit");
        
        string? stoneAmountString = Console.ReadLine();
        if (stoneAmountString == null)
        {
            Console.WriteLine("nothing is not a number");
            return AskStoneAmount();
        }
        else
        {
            int stoneAmount;
            if (int.TryParse(stoneAmountString, out stoneAmount))
            {
                if (stoneAmount >= 0)
                {
                    return stoneAmount;
                }
                else
                {
                    Console.WriteLine("Stone amount can't be negative, try again");
                    return AskStoneAmount();
                }
            }
            else
            {
                Console.WriteLine("this is not a number, try again");
                return AskStoneAmount();
            }
        }
    }

    public Game.Variant AskGameVariant()
    {
        Console.WriteLine("Please select which game you want to play, enter M/W/WC for Mancala, Wari or WarCali respectively");
        string? gameVariant = Console.ReadLine();
        if (gameVariant == null)
        {
            Console.WriteLine("nothing is not a game type");
            return AskGameVariant();
        }
        else
        {
            string GAMEVARIANT = gameVariant.ToUpper();
            if (GAMEVARIANT == "M")
            {
                return Game.Variant.Mancala;
            }
            else if (GAMEVARIANT == "W")
            {
                return Game.Variant.Wari;
            }
            else if (GAMEVARIANT == "WC")
            {
                return Game.Variant.WarCali;
            }
            else
            {
                Console.WriteLine("not a valid game type");
                return AskGameVariant();
            }
        }
    }
}

