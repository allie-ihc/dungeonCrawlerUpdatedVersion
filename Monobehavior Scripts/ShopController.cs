using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class ShopController : MonoBehaviour
{
    public GameObject shopItem;
    public TextMeshProUGUI shopText, itemText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Y) && MySingleton.thePlayer.getPoints() > 0)
        {
            shopItem.SetActive(false);
            MySingleton.thePlayer.addBonus(1);
            MySingleton.thePlayer.subtractPoins(1);
            EditorSceneManager.LoadScene("Scene1");
        }
        if(Input.GetKeyUp(KeyCode.N))
        {
            EditorSceneManager.LoadScene("Scene1");
        }
    }
}
