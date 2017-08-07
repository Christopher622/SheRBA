using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Speech bubble system that controls the visibility and content of the lower third
// speech bubble from Sherlock.

public class SpeechBubble : ClickableObject{

   public Sherlock sherlock;

   // Resets the speech bubble.
   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      sherlock.Clear();
      gameObject.SetActive(false);
   }

   public override void OnPointerEnter(PointerEventData ptrData){}
   public override void OnPointerExit(PointerEventData ptrData){}
}
