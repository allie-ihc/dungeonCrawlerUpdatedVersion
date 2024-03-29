using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon 
{
    private string name;
    private Room startRoom;
    private Room currentRoom;
    private Player thePlayer;

    public Dungeon(string name)
    {
        this.name = name;
    }

    public void setStartRoom(Room r)
    {
        this.startRoom = r;
    }
    public Room getCurrentRoom()
    {
        return currentRoom;
    }
    public void addPlayer(Player thePlayer)
    {
        this.thePlayer = thePlayer;
        this.startRoom.addPlayer(this.thePlayer);
    }
    public void setNewRoom(Room r)
    {
        this.currentRoom = r;
        this.currentRoom.addPlayer(this.thePlayer);
    }
}
