using UnityEngine;
using UnityEngine.EventSystems;

// Container for a single item that is displayed in an inventory window.

public class InvSlot : MonoBehaviour, IDropHandler{

   public Item item;
   public MsgBanner msgBanner;

   public virtual void OnDrop(PointerEventData ptrData){

      // Do nothing if an item is trying to be dropped when there already exists
      // an item for this slot.
      if(item){
         msgBanner.SetMessage("Alert!", "This slot contains an item.");
         msgBanner.Display();
         Debug.LogWarning("This slot contains an item.");
         return;
      }

      // If nothing is in this slot when an item is dragged in, then set the item's
      // current slot to this slot.

      item = ptrData.pointerDrag.GetComponent<Item>();
      item.curSlot = gameObject;

      // OnEndDrag is called on the item after this.
   }

}
