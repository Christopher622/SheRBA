using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableObject :
   MonoBehaviour,
   IBeginDragHandler,
   IDragHandler,
   IEndDragHandler
{

   protected Vector2 clickPosition;

   public virtual void OnBeginDrag(PointerEventData ptrData){
      if(GetComponent<CanvasGroup>())
         GetComponent<CanvasGroup>().blocksRaycasts = false;

      clickPosition = Input.mousePosition;
   }

   public virtual void OnDrag(PointerEventData ptrData){
      ptrData.pointerDrag.transform.position = Input.mousePosition;
   }

   public virtual void OnEndDrag(PointerEventData ptrData){
      if(GetComponent<CanvasGroup>())
         GetComponent<CanvasGroup>().blocksRaycasts = true;
   }
}
