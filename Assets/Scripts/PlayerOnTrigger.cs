using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnTrigger : MonoBehaviour
{
    public CommonEnum colType;
    void OnTriggerEnter()
    {
        colType.type = EnumTag.Player;
    }
}
