
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Button that closes the window object that is assigned here.

public class CloseInvBtn : ClickableObject {

   public GameObject window;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      window.SetActive(false);
   }

   public override void OnPointerEnter(PointerEventData ptrData){
      // NOTE:
      // The base method is not being called here because the highlight color value
      // needs to be overridden.

      Image img = gameObject.GetComponent<Image>();
      img.color = new Color32(
         0xC9, 0x00, 0x00, staticColor.a
      );
   }

}
