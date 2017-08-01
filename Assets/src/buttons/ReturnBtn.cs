using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReturnBtn : ClickableObject {

   public GameManager manager;
   public GameObject module;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      manager.SetNewModule(module);
   }

}
