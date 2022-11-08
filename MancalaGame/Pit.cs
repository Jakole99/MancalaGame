using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pit
{
    private Player.Numb _owner;
    private int stones;
    public bool IsHomePit = false;
    public int index;


    public Pit(int stones, Player.Numb owner, bool nyumba, int index)
    {
        this.stones = stones;
        this._owner = owner;
        this.index = index;
        IsHomePit = nyumba;
    }

    public int GetStoneAmount()
    {
        return stones;
    }

    public Player.Numb GetOwner()
    {
        return _owner;
    }

    public void AddStones(int amount)
    {
        stones += amount;
    }

    public void RemoveStones(int amount)
    {
        stones -= amount;
    }

    public void EmptyPit()
    {
        stones = 0;
    }

}