using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveCollison : MonoBehaviour
{
    public CommonEnum type;
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        gameObject.SetActive(false);
        switch (type.type)
        {
            case EnumTag.Player:
                break;
        }
    }
}
