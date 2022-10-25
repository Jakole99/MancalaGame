using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Board
{
    public Pit[] Pits;

    public Board(int pits, int stones)
    {
        Pits = new Pit[pits];
        MakeBoard(pits);
    }

    public abstract void FillBoard(int stones);

    public virtual void MakeBoard(int pitAmount)
    {
        int rowNormals = (pitAmount - 2) / 2;
        for (int i = 0; i < rowNormals; i++)
        {
            Pits[i] = new Pit(0, Player.Numb.P1, false);
        }
        Pits[rowNormals] = new Pit(0, Player.Numb.P1, true);
        for (int j = pitAmount/2; j < pitAmount/2 + rowNormals; j++)
        {
            Pits[j] = new Pit(0, Player.Numb.P2, false);
        }
        Pits[pitAmount - 1] = new Pit(0, Player.Numb.P2, true);
    }
    public virtual void MoveStones()
    {
        
    }
    public virtual void DrawBoard()
    {
        Pit homePitP1 = Pits[(Pits.Length - 1)];
        Pit homePitP2 = Pits[(Pits.Length / 2 - 1)];

        string row0 = "       ";
        string row1 = "_______";
        string row2 = "|      ";
        string row3 = "|----- ";
        string row4 = "||   | ";
        string row5 = "||" + numbToString(homePitP2.GetStoneAmount()) + "| ";
        string row6 = "||   | ";
        string row7 = "|----- ";
        string row8 = "|______";
        string row9 = "       ";



        for (int i = 0; i < (Pits.Length-2)/2; i++)
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

        row1 += "______";
        row2 += "     |";
        row3 += "-----|";
        row4 += "|   ||";
        row5 += "|" + numbToString(homePitP1.GetStoneAmount()) + "||";
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

} 
