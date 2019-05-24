using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveCollison : MonoBehaviour
{
    //TODO:CHANGE ALL OF THIS, IT WILL NOT SCALE!
    public CommonEnum type;
    public RingBuffer explosionDef;
    public RingBuffer explosionPlayer;

    void Awake()
    {
        explosionDef.Init();
        explosionPlayer.Init();
    }
    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        gameObject.SetActive(false);
        GameObject ownExplosion = explosionDef.GetNextObject();
        ownExplosion.transform.position = transform.position;
        ownExplosion.transform.rotation = transform.rotation;
        ownExplosion.SetActive(true);
        switch (type.type)
        {
            case EnumTag.Player:
                GameObject shipExplosion = explosionPlayer.GetNextObject();
                shipExplosion.transform.position = other.transform.position;
                shipExplosion.transform.rotation = other.transform.rotation;
                shipExplosion.SetActive(true);
                break;
        }
    }
    void Update()
    {
      
    }
}
