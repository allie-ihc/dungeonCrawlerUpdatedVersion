using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPiickup : Pickups
{
    public ArmorPiickup() : base(1)
    {
        base.name = base.name + " : ArmorPellet";
    }
}