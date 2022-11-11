using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    public Pit[] Pits;
    public bool hasHomePit;

    public Board(int pits, int stones, bool hasHomePit)
    {
        this.hasHomePit = hasHomePit;
        Pits = new Pit[pits];
        MakeBoard(pits, hasHomePit);
        FillBoard(stones);
    }

    //fills the pits in the board with stones
    public virtual void FillBoard(int stones)
    {
        foreach (Pit p in Pits)
        {
            if (!p.IsHomePit)
                p.AddStones(stones);
        }
    }

    //Added this method for testing purposes
    public void ChangeBoard(int[] boardArray)
    {
        foreach (Pit p in Pits)
        {
            if (!p.IsHomePit)
                p.EmptyPit();
        }

        for (int i = 0; i < boardArray.Length; i++)
        {
            Pits[i].AddStones(boardArray[i]);
        }
    }

    //makes the board by assigning pits
    public void MakeBoard(int pitAmount, bool hasHomePit)
    {
        int middelPoint;
        int lastPit;

        //assigning homepits and middelpoints/endpoints for the normal pits depending on board format
        if (hasHomePit)
        {
            middelPoint = (pitAmount - 2) / 2;
            lastPit = pitAmount - 1;

            Pits[middelPoint] = new Pit(0, Player.Numb.P1, true, middelPoint);
            Pits[pitAmount - 1] = new Pit(0, Player.Numb.P2, true, lastPit);
        }
        else
        {
            middelPoint = pitAmount/ 2;
            lastPit = pitAmount;
        }

        //loop the first number of non homepit pits to assign an P1 owned empty pit to them
        for (int i = 0; i < middelPoint; i++)
        {
            Pits[i] = new Pit(0, Player.Numb.P1, false, i);
        }

        //loop the second half of non homepits to assign P2 owend pits
        for (int j = pitAmount / 2; j < lastPit; j++)
        {
            Pits[j] = new Pit(0, Player.Numb.P2, false, j);
        }
    }

    
    public Pit GetOppositePit(Pit pit)
    {
        int baseindex;
        bool halfway;

        // assign variables needed for the formula to have a revolving point depending on board format
        if (hasHomePit)
        {
            baseindex = Pits.Length - 2;
            halfway = pit.index < baseindex / 2;
        }
        else
        {
            baseindex = Pits.Length - 1;
            halfway = pit.index < Pits.Length / 2;
        }

        if (halfway)
        {
            return Pits[pit.index + baseindex - (pit.index * 2)];
        }
        else
        {
            return Pits[pit.index - baseindex + (2 * (baseindex - pit.index))];
        }
    }

    // Moves the stones in a counterclockwise motion skipping homepits of the opposing player
    public virtual Pit MoveStones(int startIndex, Player.Numb player)
    {
        int stoneValue;

        // get amount of steps that need to be made
        stoneValue = Pits[startIndex].GetStoneAmount();
        Pits[startIndex].EmptyPit();

        //assign return value
        int currentIndex = startIndex;

        //loop for the amount of stones that are being moved and keep the actual index looping by using modulos of the pit amount
        for (int i = startIndex + 1; i < stoneValue + startIndex + 1; i++)
        {
            currentIndex = i % Pits.Length;

            // add a move a step to move the stone and skip the addition of one stone
            if (Pits[currentIndex].GetOwner() != player && Pits[currentIndex].IsHomePit)
            {
                stoneValue += 1;
                continue;
            }
            Pits[currentIndex].AddStones(1);
        }

        return Pits[currentIndex];
    }


    public virtual void DrawBoard(int scoreP1, int scoreP2)
    {
        // create the base strings of each row with the score of p2
        string row0 = "       ";
        string row1 = "_______";
        string row2 = "|      ";
        string row3 = "|----- ";
        string row4 = "||   | ";
        string row5 = "||" + numbToString(scoreP2) + "| ";
        string row6 = "||   | ";
        string row7 = "|----- ";
        string row8 = "|______";
        string row9 = "       ";

        int middelpoint;
        int indexpoint;

        if (hasHomePit)
        {
            middelpoint = (Pits.Length - 2) / 2;
            indexpoint = Pits.Length - 2;
        }
        else
        {
            middelpoint = Pits.Length / 2;
            indexpoint = Pits.Length - 1;
        }

        // loop for the recurring pattern in the board
        for (int i = 0; i < middelpoint; i++)
        {
            row0 += getIndexString(middelpoint - i);
            row1 += "______";
            row2 += "      ";
            row3 += "----- ";
            row4 += "|" + numbToString(Pits[indexpoint - i].GetStoneAmount()) + "| ";
            row5 += "----- ";
            row6 += "|" + numbToString(Pits[i].GetStoneAmount()) + "| ";
            row7 += "----- ";
            row8 += "______";
            row9 += getIndexString(i + 1);
        }

        // add the and of the board with the p1 score
        row1 += "______";
        row2 += "     |";
        row3 += "-----|";
        row4 += "|   ||";
        row5 += "|" + numbToString(scoreP1) + "||";
        row6 += "|   ||";
        row7 += "-----|";
        row8 += "_____|";

        Console.WriteLine(row0);
        Console.WriteLine(row1);
        Console.WriteLine(row2);
        Console.WriteLine(row3);
        Console.WriteLine(row4);
        Console.WriteLine(row5);
        Console.WriteLine(row6);
        Console.WriteLine(row7);
        Console.WriteLine(row8);
        Console.WriteLine(row9);
    }

    // helper function that takes an int and returns a string of an index of the right size for the draw function
    private string getIndexString(int numb)
    {
        if (numb > 9999)
            return "9999: ";
        else if (numb < 0)
            return "0:    ";

        string stringNumb = numb.ToString();
        string returnNumb = stringNumb + ":";

        for (int i = 0; i < 5 - stringNumb.Length ;i++)
        {
            returnNumb += " ";
        }
        return returnNumb;
    }

    // helper function that takes a int and returns a string of length three to be used in the draw function
    private string numbToString(int numb)
    {
        if (numb > 999)
            return "999";
        else if (numb < 0)
            return "  0";

        string stringNumb = numb.ToString();
        string returnNumb = "";

        for (int i = 0; i < 3 - stringNumb.Length; i++)
        {
            returnNumb += " ";
        }
        returnNumb += stringNumb;
        
        return returnNumb;
    }

    public Pit GetHomePit (Player.Numb player)
    {
        //If the board has a nyumba, Our code will make the board where the first nyumba is the middle element of the Pit array, and the second nyumba is the last element
        int middleOfTheBoard = (Pits.Length - 1) / 2; 
        int endOfTheBoard = (Pits.Length - 1);

        if (player == Player.Numb.P1)
        {
            return Pits[middleOfTheBoard];
        }
        else
        {
            return Pits[endOfTheBoard];
        }
    }

} 
