using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpeechBubble : ClickableObject{

   public Sherlock sherlock;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      sherlock.Clear();
      gameObject.SetActive(false);
   }

   public override void OnPointerEnter(PointerEventData ptrData){}
   public override void OnPointerExit(PointerEventData ptrData){}
}
