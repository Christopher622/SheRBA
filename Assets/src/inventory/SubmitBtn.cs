using UnityEngine;
using UnityEngine.EventSystems;

public class SubmitBtn : ClickableObject{

   public Inventory[] invList;
   public Sherlock sherlock;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      sherlock.SubmitEvidence(invList);
   }

}
