using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pit
{
    private Player.Numb owner;
    private int stones;
    public bool IsHomePit = false;


    public Pit(int stones, Player.Numb owner, bool nyumba)
    {
        this.stones = stones;
        this.owner = owner;
        IsHomePit = nyumba;
    }

    public int GetStoneAmount()
    {
        return stones;
    }

    public Player.Numb GetOwner()
    {
        return owner;
    }

    public void AddStones(int amount)
    {
        stones += amount;
    }

    public void RemoveStones(int amount)
    {
        stones -= amount;
    }

}