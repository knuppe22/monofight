using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Weapon
{
    public override string Name => "Fist";
    public override int Damage => 15;
    protected override int DurabilityDecrement => 0;
}
