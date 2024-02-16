using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roomExit;
    public GameObject roomEnter;
    private static bool hasExited;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasExited) { 
                EditorSceneManager.LoadScene("Scene2");
            hasExited = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        float speed = 5.0f;
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.roomExit.transform.position, speed * Time.deltaTime);
    }
}
