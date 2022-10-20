using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    public enum P1P2
    {
        P1,
        P2
    }

    public string PlayerName;
    public P1P2 PlayerNumb;

    public Player(string name, P1P2 PlayerNumb)
    {
        PlayerName = name;
        this.PlayerNumb = PlayerNumb;
    }
}