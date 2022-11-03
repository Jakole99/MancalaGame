using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    public Pit[] Pits;
    private bool hasHomePit;

    public Board(int pits, int stones, bool hasHomePit)
    {
        this.hasHomePit = hasHomePit;
        Pits = new Pit[pits];
        MakeBoard(pits, hasHomePit);
        FillBoard(stones);
    }

    public virtual void FillBoard(int stones)
    {
        foreach (Pit p in Pits)
        {
            if (!p.IsHomePit)
                p.AddStones(stones);
        }
    }

    public virtual void MakeBoard(int pitAmount, bool hasHomePit)
    {
        if (hasHomePit)
        {
            for (int i = 0; i < (pitAmount - 2) / 2; i++)
            {
                Pits[i] = new Pit(0, Player.Numb.P1, false, i);
            }
            Pits[(pitAmount - 2) / 2] = new Pit(0, Player.Numb.P1, true, (pitAmount - 2) / 2);
            for (int j = pitAmount / 2; j < pitAmount - 1; j++)
            {
                Pits[j] = new Pit(0, Player.Numb.P2, false, j);
            }
            Pits[pitAmount - 1] = new Pit(0, Player.Numb.P2, true, pitAmount - 1);
        }
        else
        {
            for (int i = 0; i < pitAmount / 2; i++)
            {
                Pits[i] = new Pit(0, Player.Numb.P1, false, i);

            }
            for (int j = pitAmount / 2; j < pitAmount; j++)
            {
                Pits[j] = new Pit(0, Player.Numb.P2, false, j);
            }
        }
        
    }

    //method to get the opposing pit on the board
    public Pit GetOppositePit(Pit pit)
    {
        //get half the boards length
        int Baseindex = Pits.Length - 2;

        if (pit.index < Baseindex)
        {
            return Pits[pit.index + Baseindex - (pit.index*2)];
        }
        else
        {
            return Pits[pit.index - Baseindex - (2*(Baseindex - pit.index))];
        }
    }


    // Moves the stones in a counterclockwise motion skipping homepits of the opposing player
    public virtual Pit MoveStones(int startIndex, Player.Numb player)
    {
        int stoneValue;

        stoneValue = Pits[startIndex].GetStoneAmount();
        Pits[startIndex].EmptyPit();

        int currentIndex = 0;
        for (int i = startIndex + 1; i < stoneValue + startIndex + 1; i++)
        {
            currentIndex = i % Pits.Length;

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

        if (hasHomePit)
        {
            for (int i = 0; i < (Pits.Length - 2) / 2; i++)
            {
                row0 += getIndexString(((Pits.Length - 2) / 2) - i);
                row1 += "______";
                row2 += "      ";
                row3 += "----- ";
                row4 += "|" + numbToString(Pits[Pits.Length - 2 - i].GetStoneAmount()) + "| ";
                row5 += "----- ";
                row6 += "|" + numbToString(Pits[i].GetStoneAmount()) + "| ";
                row7 += "----- ";
                row8 += "______";
                row9 += getIndexString(i + 1);
            }
        }
        else
        {
            for (int i = 0; i < Pits.Length / 2; i++)
            {
                row0 += getIndexString((Pits.Length / 2) - i);
                row1 += "______";
                row2 += "      ";
                row3 += "----- ";
                row4 += "|" + numbToString(Pits[Pits.Length - 1 - i].GetStoneAmount()) + "| ";
                row5 += "----- ";
                row6 += "|" + numbToString(Pits[i].GetStoneAmount()) + "| ";
                row7 += "----- ";
                row8 += "______";
                row9 += getIndexString(i + 1);
            }
        }



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
        string retrunNumb = stringNumb + ":";

        for (int i = 0; i < 5 - stringNumb.Length ;i++)
        {
            retrunNumb += " ";
        }
        return retrunNumb;
    }

    // helper function that takes a int and returns a string of lenght three to be used in the draw function
    private string numbToString(int numb)
    {
        if (numb > 999)
            return "999";
        else if (numb < 0)
            return "  0";

        string stringNumb = numb.ToString();
        string retrunNumb = "";

        for (int i = 0; i < 3 - stringNumb.Length; i++)
        {
            retrunNumb += " ";
        }
        retrunNumb += stringNumb;
        
        return retrunNumb;
    }

    public Pit GetHomePit (Player.Numb player)
    {
        int middleOfTheBoard = (Pits.Length - 1) / 2; //the first nyumba is the middle element of the Pit array, and the second nyumba is the last element
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
