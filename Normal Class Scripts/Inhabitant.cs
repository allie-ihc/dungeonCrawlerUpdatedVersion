using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;
    protected int armor = 10;
    protected int hp;

    public Inhabitant(string name)
    {
        this.name = name;
        this.hp = 100;
        this.currentRoom = null;
    }
    public int getArmor()
    {
        return armor;
    }
    public void hitHP(int amount)
    {
        hp = hp - amount;
    }
    public int getHP()
    {
        return hp;
    }
}
