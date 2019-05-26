using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    public event Action onEventRaised;
    public event Action<int> onEventRaisedInt;
    public event Action<float> onEventRaisedFloat;
}
