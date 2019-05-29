using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu]

public class GameEvent : ScriptableObject
{
    public event Action onEventRaised;
    public event Action<int> onEventRaisedInt;
    public event Action<float> onEventRaisedFloat;

    public void Raise()
    {
        onEventRaised();
    }

    public void Raise(int arg)
    {
        onEventRaisedInt(arg);
    }

    public void Raise(float arg)
    {
        onEventRaisedFloat(arg);
    }
}
