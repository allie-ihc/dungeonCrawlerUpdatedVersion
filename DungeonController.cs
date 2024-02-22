using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject frontDoor;
    public GameObject backDoor;
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject frontBlocked;
    public GameObject backBlocked;
    public GameObject leftBlocked;
    public GameObject rightBlocked;
    // Start is called before the first frame update
    void Start()
    {
        Room r = new Room("a room", MySingleton.nextEnter);
        if(r.getLeftExitEnabled() == false)
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
        }
        MySingleton.addRoom(r);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
