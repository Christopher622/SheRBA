using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject :
   MonoBehaviour,
   IState,
   IPointerClickHandler,
   IPointerDownHandler,
   IPointerUpHandler,
   IPointerEnterHandler,
   IPointerExitHandler
{
   public readonly Color32 hoverColor = new Color32(0x0, 0xff, 0xff, 0xff);
   protected Color32 staticColor;

   void Start(){
      if(gameObject.GetComponent<Image>())
         staticColor = gameObject.GetComponent<Image>().color;
   }

   public virtual void ResetState(){
      if(gameObject.GetComponent<Image>())
         gameObject.GetComponent<Image>().color = staticColor;
   }

   public virtual void OnPointerClick(PointerEventData ptrData){

   }

   public virtual void OnPointerEnter(PointerEventData ptrData){
      Image img = gameObject.GetComponent<Image>();
      img.color = new Color32(
         hoverColor.r, hoverColor.g, hoverColor.b, staticColor.a
      );
   }

   public virtual void OnPointerExit(PointerEventData ptrData){
      Image img = gameObject.GetComponent<Image>();
      img.color = staticColor;
   }

   public virtual void OnPointerUp(PointerEventData ptrData){

   }

   public virtual void OnPointerDown(PointerEventData ptrData){

   }
}
