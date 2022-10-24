using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public Player(string name, Numb PlayerNumb)
    {
        PlayerName = name;
        this.PlayerNumb = PlayerNumb;
    }
}