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
    public EnumTag type;
}