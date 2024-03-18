using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    /*public GameObject frontDoor;
    public GameObject backDoor;
    public GameObject leftDoor;
    public GameObject rightDoor; */
    public GameObject frontBlocked;
    public GameObject backBlocked;
    public GameObject leftBlocked;
    public GameObject rightBlocked;
    public GameObject frontPickUp;
    public GameObject backPickUp;
    public GameObject leftPickUp;   
    public GameObject rightPickUp;
    // Start is called before the first frame update
    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("front"))
        {
          //  this.frontDoor.SetActive(true);
            this.frontBlocked.SetActive(false);
        }
        else
        {
            this.frontBlocked.SetActive(true);
        }

        if (theCurrentRoom.hasExit("back"))
        {
          //  this.backDoor.SetActive(false);
            this.backBlocked.SetActive(false);
        }
        else
        {
            this.backBlocked.SetActive(true);
        }

        if (theCurrentRoom.hasExit("left"))
        {
           // this.leftDoor.SetActive(false);
            this.leftBlocked.SetActive(false);
        }
        else
        {
            this.leftBlocked.SetActive(true);
        }

        if (theCurrentRoom.hasExit("right"))
        {
          //  this.rightDoor.SetActive(false);
            this.rightBlocked.SetActive(false);
        }
        else
        {
            this.rightBlocked.SetActive(true);
        }

        if(!theCurrentRoom.getPickUpCollected("front"))
        {
            frontPickUp.SetActive(true);
        }
        if (!theCurrentRoom.getPickUpCollected("back"))
        {
            backPickUp.SetActive(true);
        }
        if (!theCurrentRoom.getPickUpCollected("left"))
        {
            leftPickUp.SetActive(true);
        }
        if (!theCurrentRoom.getPickUpCollected("right"))
        {
            rightPickUp.SetActive(true);
        }

    }

    private void enableExits(Room r)
    {
     /*   if (r.getLeftExitEnabled() == false)
        {
            leftDoor.SetActive(false);
            MySingleton.leftExitEnabled = false;
            leftBlocked.SetActive(true);
        }
        else
        {
            leftDoor.SetActive(true);
            MySingleton.leftExitEnabled = true;
            leftBlocked.SetActive(false);
        }
        if (r.getRightExitEnabled() == false)
        {
            rightDoor.SetActive(false);
            MySingleton.rightExitEnabled = false;
            rightBlocked.SetActive(true);
        }
        else
        {
            rightDoor.SetActive(true);
            MySingleton.rightExitEnabled = true;
            rightBlocked.SetActive(false);
        }
        if (r.getFrontExitEnabled() == false)
        {
            frontDoor.SetActive(false);
            MySingleton.frontExitEnabled = false;
            frontBlocked.SetActive(true);
        }
        else
        {
            frontDoor.SetActive(true);
            MySingleton.frontExitEnabled = true;
            frontBlocked.SetActive(false);
        }
        if (r.getBackExitEnabled() == false)
        {
            backDoor.SetActive(false);
            MySingleton.backExitEnabled = false;
            backBlocked.SetActive(true);
        }
        else
        {
            backDoor.SetActive(true);
            MySingleton.backExitEnabled = true;
            backBlocked.SetActive(false);
        } */
    }
}
