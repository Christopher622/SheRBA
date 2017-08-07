using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Button object that calls GameManager to unload the current module, and load
// the one assigned to this button.

// TODO:
// Needs to be condensed into a base class.

public class ReturnBtn : ClickableObject {

   public GameManager manager;
   public GameObject module;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      manager.SetNewModule(module);
   }

}
