using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// SUMMARY:
// Base object class that contains functionality for objects that can be clicked.
// This object is intended to be inherited by another class that provides additional
// functionality to the below methods.

public class ClickableObject :
   MonoBehaviour,
   IState,
   IPointerClickHandler,
   IPointerDownHandler,
   IPointerUpHandler,
   IPointerEnterHandler,
   IPointerExitHandler
{
   // Default highlight color on mouse over.
   public readonly Color32 hoverColor = new Color32(0x0, 0xff, 0xff, 0xff);

   protected Color32 staticColor;

   void Start(){
      // Preserve the default static color.
      if(gameObject.GetComponent<Image>())
         staticColor = gameObject.GetComponent<Image>().color;
   }

   // Implemented method that resets the variables to their default on this object.
   public virtual void ResetState(){
      if(gameObject.GetComponent<Image>())
         gameObject.GetComponent<Image>().color = staticColor;
   }

   // No default implementation.
   // Intended to be overridden.
   public virtual void OnPointerClick(PointerEventData ptrData){

   }

   // Change the color on mouse over.
   // Intended to be overridden.
   // The base method should always be called first before overridden implementation.
   public virtual void OnPointerEnter(PointerEventData ptrData){
      Image img = gameObject.GetComponent<Image>();
      img.color = new Color32(
         hoverColor.r, hoverColor.g, hoverColor.b, staticColor.a
      );
   }

   // Change the color back to default static.
   // Intended to be overridden.
   // The base method should always be called first before overridden implementation.
   public virtual void OnPointerExit(PointerEventData ptrData){
      Image img = gameObject.GetComponent<Image>();
      img.color = staticColor;
   }

   // No default implementation.
   // Intended to be overridden.
   public virtual void OnPointerUp(PointerEventData ptrData){

   }

   // No default implementation.
   // Intended to be overridden.
   public virtual void OnPointerDown(PointerEventData ptrData){

   }
}
