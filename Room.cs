using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    private string name;
    private int numExits;
    //left, right, front, back
    private bool[] exitsEnabled = new bool[4];
    public Room (string name, string mustIncludeExit)
    {
        this.name = name;
        this.numExits = Random.Range(1, 4);
        if(mustIncludeExit != " ")
        {
            if(mustIncludeExit.Equals("left"))
            {
                exitsEnabled[0] = true;
            }
            else if(mustIncludeExit.Equals("right"))
            {
                exitsEnabled[1] = true;
            }
            else if(mustIncludeExit.Equals("front"))
            {
                exitsEnabled[2] = true;
            }
            else if(mustIncludeExit.Equals("back"))
            {
                exitsEnabled[3] = true;
            }
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
        }
    }
    public bool getLeftExitEnabled()
    {
        return exitsEnabled[0];
    }
    public bool getRightExitEnabled()
    {
        return exitsEnabled[1];
    }
    public bool getFrontExitEnabled()
    {
        return exitsEnabled[2];
    }
    public bool getBackExitEnabled()
    {
        return exitsEnabled[3];
    }
}
