using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SherlockStudyBtn : ClickableObject {

   public GameManager manager;
   public GameObject studyModule;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      manager.SetNewModule(studyModule);
   }

}
