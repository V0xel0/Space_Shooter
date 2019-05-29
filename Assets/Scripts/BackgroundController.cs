using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed = 0.1f;
    private Renderer rndr;

    void Start ()
    {
        rndr = GetComponent <Renderer> ();
    }

    void Update ()
    {
        float offset = Time.time * speed;
        rndr.material.mainTextureOffset = new Vector2 (0.0f, offset);
    }
}
