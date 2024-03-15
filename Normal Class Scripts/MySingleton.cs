using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
    public static string currentDirection = " ";
    public static Player thePlayer;
    public static Dungeon theDungeon = MySingleton.generateDungeon();
    public static Dungeon generateDungeon()
    {
        Room r1 = new Room("R1");
        Room r2 = new Room("R2");
        Room r3 = new Room("R3");
        Room r4 = new Room("R4");
        Room r5 = new Room("R5");
        Room r6 = new Room("R6");

        r1.addExit("front", r2);
        r2.addExit("back", r1);
        r2.addExit("front", r3);
        r3.addExit("back", r2);
        r3.addExit("right", r4);
        r3.addExit("front", r6);
        r3.addExit("left", r5);
        r4.addExit("left", r3);
        r5.addExit("right", r3);
        r6.addExit("back", r3);

        Dungeon theDungeon = new Dungeon("the cross");
        theDungeon.setStartRoom(r1);
        MySingleton.thePlayer = new Player("Mike");
        theDungeon.addPlayer(MySingleton.thePlayer);
        return theDungeon;
    }
    public static void changeRoom(Room r)
    {
        theDungeon.setNewRoom(r);
    }
    /*  public static Room loadRoom(Room r)
      {
          if (r.getEnterToOtherRoom().Equals(currentDirection))
          {
              for (int i = 0; i < numRooms; i++)
              {
                  if (rooms[i].getName().Equals(r.getEnterRoom()))
                      {

                      return rooms[i];
                  }
              }
          }
          return null;
      }*/
}