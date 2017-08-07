using UnityEngine;
using UnityEngine.EventSystems;

public class StartBtn : ClickableObject {

   public GameManager manager;
   public GameObject worldMap;

   // Button object that calls GameManager to unload the current module, and load
   // the one assigned to this button.

   // TODO:
   // Needs to be condensed into a base class.

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      manager.SetNewModule(worldMap);
   }

}
