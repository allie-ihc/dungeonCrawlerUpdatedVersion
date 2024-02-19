using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

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

    private void turnOffExits()
    {
        this.frontExit.gameObject.SetActive(false);
        this.backExit.gameObject.SetActive(false);
        this.leftExit.gameObject.SetActive(false);
        this.rightExit.gameObject.SetActive(false);
    }
    private void turnOnExits()
    {
        this.frontExit.gameObject.SetActive(true);
        this.backExit.gameObject.SetActive(true);
        this.leftExit.gameObject.SetActive(true);
        this.rightExit.gameObject.SetActive(true);
    }
    void Start()
    {
        this.turnOffExits();

        if (!MySingleton.currentDirection.Equals(" "))
        {
            if(MySingleton.currentDirection.Equals("front"))
            {
                this.gameObject.transform.position = this.backExit.transform.position;
                this.amAtMiddleOfRoom = false;
            } 
            else if(MySingleton.currentDirection.Equals("right"))
            {
                this.gameObject.transform.position = this.leftExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
            else if(MySingleton.currentDirection.Equals("back"))
            {
                this.gameObject.transform.position = this.frontExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
            else if(MySingleton.currentDirection.Equals("left"))
            {
                this.gameObject.transform.position = this.rightExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
        }
       // MySingleton.currentDirection = " ";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Scene1");
        }
        else if(other.CompareTag("middleOfRoom") && !MySingleton.currentDirection.Equals(" "))
        {
            this.amAtMiddleOfRoom = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(this.amAtMiddleOfRoom)
        {
            amMoving = false;
            MySingleton.currentDirection = " ";
        }
        if (Input.GetKeyUp(KeyCode.W) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "front";

            this.amAtMiddleOfRoom = false;
        }
        if (Input.GetKeyUp(KeyCode.A) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "left";

            this.amAtMiddleOfRoom = false;
            }
        if (Input.GetKeyUp(KeyCode.S) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "back";

            this.amAtMiddleOfRoom = false;
            }
        if (Input.GetKeyUp(KeyCode.D) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "right";

            this.amAtMiddleOfRoom = false;
            }

       if (MySingleton.currentDirection.Equals("front"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.frontExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(frontExit.transform);
        }            
        if (MySingleton.currentDirection.Equals("back"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.backExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(backExit.transform);
        }
        if (MySingleton.currentDirection.Equals("right"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.rightExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(rightExit.transform);
        }
        if (MySingleton.currentDirection.Equals("left"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.leftExit.transform.position, this.speed * Time.deltaTime);
            this.gameObject.transform.LookAt(leftExit.transform);
        }
    }
}
