using UnityEngine;
using UnityEngine.EventSystems;

public class StartBtn : ClickableObject, IState {

   public GameManager manager;
   public GameObject worldMap;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      manager.SetNewModule(worldMap);
   }

}
