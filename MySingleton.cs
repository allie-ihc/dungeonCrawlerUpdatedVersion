using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton 
{
    public static string currentDirection = " ";
    public static Room[] rooms = new Room[100];
    public static int numRooms = 0;
    public static string nextEnter = " ";
    public static bool frontExitEnabled = false;
    public static bool backExitEnabled = false;
    public static bool rightExitEnabled = false;
    public static bool leftExitEnabled = false;
    public static void addRoom(Room r)
    {
        rooms[numRooms] = r;
        numRooms++;
    }
}
