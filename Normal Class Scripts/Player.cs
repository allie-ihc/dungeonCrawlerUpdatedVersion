using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Inhabitant
{
    private int points;

    public Player(string name) : base(name)
    {
        
        this.name = name;
        this.currentRoom = null;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }
    public int getPoints()
    {
        return this.points;
    }

    public void addPoint()
    {
        points++;
    }
}
