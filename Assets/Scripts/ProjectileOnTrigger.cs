using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOnTrigger : MonoBehaviour
{
    public CommonEnum colType;
    void OnTriggerEnter()
    {
        colType.type = EnumTag.Bullet;
    }
}
