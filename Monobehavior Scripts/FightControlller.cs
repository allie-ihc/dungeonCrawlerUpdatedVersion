using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshProUGUI hero_hp_TMP, monster_hp_TMP;
    public Vector3 playerPosition;
    public Vector3 monsterPosition;
    private bool playerTurn = true;
    private bool fightOver = false;

    // Start is called before the first frame update
    void Start()
    {
        hero_hp_TMP.text = "Player HP: " + MySingleton.thePlayer.getHP();
        monster_hp_TMP.text = "Monster HP: " + MySingleton.theMonster.getHP();
        playerPosition = hero_GO.transform.position;
        monsterPosition = monster_GO.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Fight());
    }
    IEnumerator Fight()
    {
        while (!fightOver)
        {
            Attack();
            yield return new WaitForSeconds(5000.0f);
        }
    }
    void Attack()
    {
        if (playerTurn)
        {
            hero_GO.transform.position = Vector3.MoveTowards(hero_GO.transform.position, monster_GO.transform.position, 0.5f);
            int rollTwenty = Random.Range(0, 20);
            if (rollTwenty > MySingleton.theMonster.getArmor())
            {
                int damage = Random.Range(0, 6);
                MySingleton.theMonster.hitHP(damage);
                monster_hp_TMP.text = "Monster HP: " + MySingleton.theMonster.getHP();
            }
            if (MySingleton.thePlayer.getHP() <= 0)
            {
                fightOver = true;
                hero_hp_TMP.text = "Game Over";
                StopAllCoroutines();
            }
            hero_GO.transform.position = Vector3.MoveTowards(hero_GO.transform.position, playerPosition, 0.5f);
            playerTurn = false;
        }
        else
        {
            monster_GO.transform.position = Vector3.MoveTowards(monster_GO.transform.position, hero_GO.transform.position, 0.5f);
            int rollTwenty = Random.Range(0, 20);
            if (rollTwenty > MySingleton.thePlayer.getArmor())
            {
                int damage = Random.Range(0, 6);
                MySingleton.thePlayer.hitHP(damage);
            }
            if (MySingleton.theMonster.getHP() <= 0)
            {
                fightOver = true;
                monster_hp_TMP.text = "Game Over";
                StopAllCoroutines();
            }
            hero_GO.transform.position = Vector3.MoveTowards(monster_GO.transform.position, monsterPosition, 0.5f);
            playerTurn = true;
        }

    }
}