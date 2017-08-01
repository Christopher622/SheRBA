using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler{
	public void OnPointerClick(PointerEventData ptrData){
		Debug.Log("Click");
   }

   public void OnPointerEnter(PointerEventData ptrData){
   	Debug.Log("Enter");
   }

   public void OnPointerExit(PointerEventData ptrData){
   	Debug.Log("Exit");
   }
}