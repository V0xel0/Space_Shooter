using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Boundry
{
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

}
public class PlayerController : MonoBehaviour
{
    public Health  maxHealth;
    public Speed speed;
    public Boundry boundry;
    
    public GameEvent receivedDmg;
    public GameEvent playerHpChanged;
    
    public GameObject selfExplosion;
    public GameObject[] looks;
    public float tilt;

    private Health currHealth;
    private Vector3 movement;
    private Rigidbody rb;
    private int indexLook;

    private void Awake()
    {
        looks[indexLook].SetActive(true);
        selfExplosion = Instantiate(selfExplosion);
        selfExplosion.SetActive(false);
    }

    private void Start()
    {
        currHealth.value = maxHealth.value;
        movement = new Vector3(0.0f, 0.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
        receivedDmg.onEventRaisedFloat += OnRecievedDmg;
    }

    private void OnDisable()
    {
        if (selfExplosion == null)
            return;
        selfExplosion.transform.position = transform.position;
        selfExplosion.SetActive(true);
        receivedDmg.onEventRaisedFloat -= OnRecievedDmg;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            looks[indexLook].SetActive(false);
            indexLook = 1;
            looks[indexLook].SetActive(true);
        }
    }

    private void OnEnable()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        rb.velocity = movement*speed.value;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundry.minX, boundry.maxX),
            0.0f,
            Mathf.Clamp(rb.position.z, boundry.minZ, boundry.maxZ)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    private void OnRecievedDmg(float dmg)
    {
        currHealth.value -= dmg;
        playerHpChanged.Raise(currHealth.value/maxHealth.value);
        
        if (currHealth.value <= 0)
        {
            gameObject.SetActive(false); //TODO:: Later make it event that player dies
        }
    }
}
