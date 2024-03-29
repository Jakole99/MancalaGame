﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI
{
    public string AskPlayerName()
    {
        DisplayMessage("Please enter a username");

        return GetString();
    }

    public Game.Variant AskGameVariant()
    {
        DisplayMessage("Please select which game you want to play, enter M/W/WC for Mancala, Wari or WarCali respectively");
        string? gameVariant = Console.ReadLine();
        
        string gameVariantUpper = gameVariant.ToUpper();
        if (gameVariantUpper == "M")
        {
            return Game.Variant.Mancala;
        }
        else if (gameVariantUpper == "W")
        {
            return Game.Variant.Wari;
        }
        else if (gameVariantUpper == "WC")
        {
            return Game.Variant.WarCali;
        }
        else
        {
            DisplayMessage("not a valid game type");
            return AskGameVariant();
        }
    }

    public bool AskStandardOptions()
    {
        DisplayMessage("Do you want to use the standard settings? type Y for yes or N for no");

        string standardOptions = GetString();
        if (standardOptions.ToUpper() == "Y")
        {
            return true;
        }
        else if (standardOptions.ToUpper() == "N")
        {
            return false;
        }
        else
        {
            DisplayMessage("Invalid options");
            return AskStandardOptions();
        }
    }

    public int AskPitAmount()
    {
        DisplayMessage("Please enter an even amount of pits that is greater than 2, you would like to use (homepits count as pits):");

        int pits = GetInteger();

        if (pits > 3 && pits % 2 == 0)
        {
            return pits;
        }
        else
        {
            DisplayMessage("invalid number, try again");
            return AskPitAmount();
        }
    }

    public int AskStoneAmount()
    {
        DisplayMessage("Please enter the amount of stones you would like to be added to each pit");

        int stones = GetInteger();

        if (stones >= 0)
        {
            return stones;
        }
        else
        {
            DisplayMessage("Stone amount can't be negative, try again");
            return AskStoneAmount();
        }
    }


    public virtual int GetInteger()
    {
        string? number = Console.ReadLine();
        int numb;
        
        if (int.TryParse(number, out numb))
        {
            return numb;
        }
        else
        {
            DisplayMessage("please enter a number");
            return GetInteger();
        }
    }

    public string GetString()
    {
        return Console.ReadLine();
    }

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
}

