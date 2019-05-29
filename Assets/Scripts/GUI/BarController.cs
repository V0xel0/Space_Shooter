using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
   [SerializeField]
   private RectTransform barRect;

   [SerializeField]
   private GameEvent changeEvent;
   private void Start()
   {
      changeEvent.onEventRaisedFloat += onChangeEvent;

   }

   private void onChangeEvent(float percentage)
   {
      var localScale = barRect.localScale;
      localScale = new Vector3(percentage, localScale.y, localScale.z);
      barRect.localScale = localScale;
   }

   private void OnDisable()
   {
      changeEvent.onEventRaisedFloat -= onChangeEvent;
   }
}