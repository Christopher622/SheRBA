using UnityEngine;
using UnityEngine.EventSystems;

// Special kind of button that holds a list to multiple inventories that are
// sumbited to Sherlock for him to analyze.

public class SubmitBtn : ClickableObject{

   public Inventory[] invList;
   public Sherlock sherlock;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      sherlock.SubmitEvidence(invList);
   }

}
