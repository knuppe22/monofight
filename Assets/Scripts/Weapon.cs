using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public abstract string Name {get;}
    public abstract int Damage {get;}
    public virtual int Durability { get; private set; } = 10;
    protected virtual int DurabilityDecrement { get; } = 1;

    // 만약 내구도가 다했으면 true 리턴
    public bool OnAttack()
    {
        Durability -= DurabilityDecrement;
        return Durability <= 0;
    }
}
