using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Button that toggles the referenced window visibility.

public class OpenInvBtn : ClickableObject {

   public GameObject window;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      if(window.activeSelf)
         window.SetActive(false);
      else
         window.SetActive(true);
   }

}
