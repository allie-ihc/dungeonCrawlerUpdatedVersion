using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    // Start is called before the first frame update
    protected int bonus;
    protected string name;

    public Pickups(int bonus)
    {
        this.bonus = bonus;
        this.name = "pellet";
    }
 
}
