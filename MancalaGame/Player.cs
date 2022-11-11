using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

public class Player
{
    public enum Numb
    {
        P1,
        P2,
        None
    }

    public string PlayerName;
    public Numb PlayerNumb;
    public int score = 0;

    public Player(string name, Numb PlayerNumb)
    {
        PlayerName = name;
        this.PlayerNumb = PlayerNumb;
    }

}