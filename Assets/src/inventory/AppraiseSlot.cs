using UnityEngine;
using UnityEngine.EventSystems;

// Container for items that Sherlock can appraise.

public class AppraiseSlot : InvSlot {

   public Sherlock sherlock;

   public override void OnDrop(PointerEventData ptrData){
      base.OnDrop(ptrData);

      sherlock.DoSpeech(item.appraisalSpeech);
   }
}
