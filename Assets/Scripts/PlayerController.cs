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
    public float speed;
    public float tilt;
    public Boundry boundry;
    public CommonEnum type;

    private Rigidbody rb;
    private Vector3 movement;
    private int internalMagazine;

    void OnTriggerEnter()
    {
        type.type = EnumTag.Player;
    }
    void Start()
    {
        movement = new Vector3(0.0f, 0.0f, 0.0f);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        rb.velocity = movement*speed;
        //Wouldnt simple "else if" be better???
       //WHY THE FUCK SET() IS NOT WORKING??

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundry.minX, boundry.maxX),
            0.0f,
            Mathf.Clamp(rb.position.z, boundry.minZ, boundry.maxZ)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
