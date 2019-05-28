using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    public SharedInt score;
    public GameEvent onKill;
    
    private TextMeshPro text;
    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
        onKill.onEventRaised += ChangeScore;
    }
 
    private void ChangeScore()
    {
        score.value++;
        text.text = score.value.ToString();
    }
}
