using UnityEngine;
using UnityEngine.EventSystems;

public class LocationNode : ClickableObject {

	public GameObject siteModule;
	public GameObject textPopup;

	public override void ResetState(){
		textPopup.SetActive(false);
	}

	public override void OnPointerClick(PointerEventData ptrData){
		GameManager.inst.SetNewModule(siteModule);
   }

   public override void OnPointerEnter(PointerEventData ptrData){
   	textPopup.SetActive(true);
   }

   public override void OnPointerExit(PointerEventData ptrData){
   	textPopup.SetActive(false);
   }

}
