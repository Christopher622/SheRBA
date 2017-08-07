using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Base class for any kind of object that can be clicked and dragged.

public class DraggableObject :
   MonoBehaviour,
   IBeginDragHandler,
   IDragHandler,
   IEndDragHandler
{

   protected Vector2 clickPosition;

   public virtual void OnBeginDrag(PointerEventData ptrData){

      // The cursor raycast needs to pass through the dragging object so it can
      // detect inventory slots or other containers that this object can be
      // dropped in.

      if(GetComponent<CanvasGroup>())
         GetComponent<CanvasGroup>().blocksRaycasts = false;

      clickPosition = Input.mousePosition;
   }

   // Updates every tick.
   public virtual void OnDrag(PointerEventData ptrData){
      ptrData.pointerDrag.transform.position = Input.mousePosition;
   }

   public virtual void OnEndDrag(PointerEventData ptrData){
      if(GetComponent<CanvasGroup>())
         GetComponent<CanvasGroup>().blocksRaycasts = true;
   }
}
