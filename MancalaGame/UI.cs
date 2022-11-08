using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI
{
    public string AskPlayerName()
    {
        Console.WriteLine("Please enter a username");

        return (Console.ReadLine());
    }



    public Game.Variant AskGameVariant()
    {
        Console.WriteLine("Please select which game you want to play, enter M/W/WC for Mancala, Wari or WarCali respectively");
        string? gameVariant = Console.ReadLine();
        
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

    public bool AskStanderdOptions()
    {
        Console.WriteLine("Do you want to use the standerd settings? type Y for yes or N for no");

        string? standerdOptions = Console.ReadLine();
        if (standerdOptions.ToUpper() == "Y")
        {
            return true;
        }
        else if (standerdOptions.ToUpper() == "N")
        {
            return false;
        }
        else
        {
            Console.WriteLine("Invalid options");
            return AskStanderdOptions();
        }
    }

    public int AskPitAmount()
    {
        Console.WriteLine("Please enter an even amount of pits that is greater 2 you would like to use (homepits count as pits):");

        string? pitAmountString = Console.ReadLine();

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

    public int AskStoneAmount()
    {
        Console.WriteLine("Please enter the amount of stones you would like to be added to each pit");

        string? stoneAmountString = Console.ReadLine();
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

