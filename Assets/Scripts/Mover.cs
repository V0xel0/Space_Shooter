using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[ExecuteInEditMode]
public class Mover : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnBecameInvisible()
    {
       gameObject.SetActive(false);
    }
    void OnEnable()
    {
        
    }

}
