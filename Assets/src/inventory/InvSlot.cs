using UnityEngine;
using UnityEngine.EventSystems;

public class InvSlot : MonoBehaviour, IDropHandler{

   public Item item;
   public MsgBanner msgBanner;

   public virtual void OnDrop(PointerEventData ptrData){

      if(item){
         msgBanner.SetMessage("Alert!", "This slot contains an item.");
         msgBanner.Display();
         Debug.LogWarning("This slot contains an item.");
         return;
      }

      item = ptrData.pointerDrag.GetComponent<Item>();
      item.curSlot = gameObject;
   }

}
