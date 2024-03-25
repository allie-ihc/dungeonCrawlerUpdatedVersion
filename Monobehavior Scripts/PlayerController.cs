using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject frontExit;
    public GameObject backExit;
    public GameObject leftExit;
    public GameObject rightExit;
    public GameObject roomEnter;
    public float speed = 5.0f;
    private bool amMoving = false;
    public bool amAtMiddleOfRoom = false;
    public bool reachedMiddle = false;
    private string exitUsed;
    public TextMeshProUGUI pointsDisplay;
    private void turnOffExits()
    {
        this.frontExit.gameObject.SetActive(false);
        this.backExit.gameObject.SetActive(false);
        this.leftExit.gameObject.SetActive(false);
        this.rightExit.gameObject.SetActive(false);
    }
    private void turnOnExits()
    {
        if (MySingleton.thePlayer.getCurrentRoom().hasExit("front"))
        {
            this.frontExit.gameObject.SetActive(true);
        }
        if (MySingleton.thePlayer.getCurrentRoom().hasExit("back"))
        {
            this.backExit.gameObject.SetActive(true);
        }
        if (MySingleton.thePlayer.getCurrentRoom().hasExit("left"))
        {
            this.leftExit.gameObject.SetActive(true);
        }
        if (MySingleton.thePlayer.getCurrentRoom().hasExit("right"))
        {
            this.rightExit.gameObject.SetActive(true);
        }
    }
    void Start()
    {
        pointsDisplay.text = MySingleton.thePlayer.getPoints().ToString();
        this.turnOffExits();

        if (!MySingleton.currentDirection.Equals(" "))
        {
            if (MySingleton.currentDirection.Equals("front"))
            {
                this.gameObject.transform.position = this.backExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("right"))
            {
                this.gameObject.transform.position = this.leftExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("back"))
            {
                this.gameObject.transform.position = this.frontExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("left"))
            {
                this.gameObject.transform.position = this.rightExit.transform.position;
            }
            this.amAtMiddleOfRoom = false;
        }
        else
        {
            roomEnter.SetActive(false);
            turnOnExits();
            reachedMiddle = true;
        }
        // MySingleton.currentDirection = " ";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            MySingleton.changeRoom(MySingleton.thePlayer.getCurrentRoom().getExitDestinationRoom(MySingleton.currentDirection));
            EditorSceneManager.LoadScene("Scene1");
        }
        else if (other.CompareTag("middleOfRoom") && !MySingleton.currentDirection.Equals(" "))
        {
            this.amAtMiddleOfRoom = true;
            this.reachedMiddle = true;
            turnOnExits();
        }
        else if (other.CompareTag("pickUp"))
        {
            EditorSceneManager.LoadScene("Scene2");

         /*   other.gameObject.SetActive(false);
            MySingleton.thePlayer.addPoint();
            pointsDisplay.text = MySingleton.thePlayer.getPoints().ToString(); */
         /*   if (reachedMiddle)
            {
                MySingleton.theDungeon.getCurrentRoom().setPickUpCollected(MySingleton.currentDirection);
            }
            else
            {
                if(MySingleton.currentDirection.Equals("front"))
                {
                    MySingleton.theDungeon.getCurrentRoom().setPickUpCollected("back");
                }
                if (MySingleton.currentDirection.Equals("back"))
                {
                    MySingleton.theDungeon.getCurrentRoom().setPickUpCollected("front");
                }
                if (MySingleton.currentDirection.Equals("right"))
                {
                    MySingleton.theDungeon.getCurrentRoom().setPickUpCollected("left");
                }
                if (MySingleton.currentDirection.Equals("left"))
                {
                    MySingleton.theDungeon.getCurrentRoom().setPickUpCollected("right");
                }
            } */
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (this.amAtMiddleOfRoom)
        {
            amMoving = false;
            MySingleton.currentDirection = " ";
        }
        if (Input.GetKeyUp(KeyCode.W) && !this.amMoving && this.frontExit.activeInHierarchy == true)
        {
            //MySingleton.nextEnter = "front";
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "front";

            this.amAtMiddleOfRoom = false;
        }
        if (Input.GetKeyUp(KeyCode.A) && !this.amMoving && this.leftExit.activeInHierarchy == true)
        {
           // MySingleton.nextEnter = "left";
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "left";

            this.amAtMiddleOfRoom = false;
        }
        if (Input.GetKeyUp(KeyCode.S) && !this.amMoving && this.backExit.activeInHierarchy == true)
        {
          //  MySingleton.nextEnter = "back";
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "back";

            this.amAtMiddleOfRoom = false;
        }
        if (Input.GetKeyUp(KeyCode.D) && !this.amMoving && this.rightExit.activeInHierarchy == true)
        {
           // MySingleton.nextEnter = "right";
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "right";

            this.amAtMiddleOfRoom = false;
        }

        if (MySingleton.currentDirection.Equals("front"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.frontExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(frontExit.transform);
           // roomEnter.SetActive(true);
        }
        if (MySingleton.currentDirection.Equals("back"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.backExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(backExit.transform);
          //  roomEnter.SetActive(true);
        }
        if (MySingleton.currentDirection.Equals("right"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.rightExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(rightExit.transform);
          //  roomEnter.SetActive(true);
        }
        if (MySingleton.currentDirection.Equals("left"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.leftExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(leftExit.transform);
         //   roomEnter.SetActive(true);
        }
    }
}
