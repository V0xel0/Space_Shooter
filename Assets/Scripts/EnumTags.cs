using System;
using UnityEngine;
public enum EnumTag
{
    Player,
    Asteroid,
    EvilShip,
    Bullet
}

[CreateAssetMenu]
public class CommonEnum : ScriptableObject
{
    [NonSerialized]
    public EnumTag type;
}