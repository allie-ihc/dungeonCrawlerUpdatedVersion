using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Room
{
    private string name;
    //  private int numExits;
    //left, right, front, back
    private bool[] exitsEnabled = new bool[4];
    // private string enterToOtherRoom = " ";
    // private string enterRoom = " ";
    private Exit[] theExits = new Exit[4];
    private string[] pickUps = new string[4];
    private bool[] pickUpsEnabled = {false,false,false,false};
    private int howManyExits = 0;
    private Player currentPlayer;
    public Room(string name)
    {
        this.name = name;
        this.pickUps[0] = "front";
        this.pickUps[1] = "back";
        this.pickUps[2] = "left";
        this.pickUps[3] = "right";
        //  this.numExits = Random.Range(1, 4);
        /*    if(mustIncludeExit != " ")
            {
                if(mustIncludeExit.Equals("right"))
                {
                    exitsEnabled[0] = true;
                }
                else if(mustIncludeExit.Equals("left"))
                {
                    exitsEnabled[1] = true;
                }
                else if(mustIncludeExit.Equals("back"))
                {
                    exitsEnabled[2] = true;
                }
                else if(mustIncludeExit.Equals("front"))
                {
                    exitsEnabled[3] = true;
                }
                numExits--;
            }
            for(int i = 0; i < numExits; i++)
            {
                int temp = Random.Range(0, 3);
                if (exitsEnabled[temp] == true)
                {
                    i--;
                }

                else
                {
                    exitsEnabled[temp] = true;
                }
            } */
    }

    public void setPickUpCollected(string direction)
    {
        for (int i = 0; i < pickUps.Length; i++)
        {
            if (pickUps[i].Equals(direction))
            {
                pickUpsEnabled[i] = false;
            }
        }
    }

    public bool getPickUpCollected(string direction)
    {
        for (int i = 0; i < pickUps.Length; i++)
        {
            if (pickUps[i].Equals(direction))
            {
                return !pickUpsEnabled[i];
            }
        }
        return false;
    }
    public void addExit(string direction, Room destinationRoom)
    {
        if(this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;
            for (int i = 0; i < pickUps.Length; i++)
            {
                if (pickUps[i].Equals(direction))
                {
                    pickUpsEnabled[i] = true;
                }
            }
        }
    }
    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);
    }

    public string getName()
    {
        return name;
    }
    public bool hasExit(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }
    public Room getExitDestinationRoom(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return theExits[i].getDestinationRoom();
            }
        }
        return null;
    }

}
