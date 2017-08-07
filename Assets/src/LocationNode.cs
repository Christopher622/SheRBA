using UnityEngine;
using UnityEngine.EventSystems;

// Event handler for location nodes on the world map.

public class LocationNode : ClickableObject {

	public GameObject siteModule;
	public GameObject textPopup;

	public override void ResetState(){
		textPopup.SetActive(false);
	}

	// Load the module assigned here.
	public override void OnPointerClick(PointerEventData ptrData){
		GameManager.inst.SetNewModule(siteModule);
   }

	// Activate tooltip.
   public override void OnPointerEnter(PointerEventData ptrData){
   	textPopup.SetActive(true);
   }

	// Deactivate tooltip.
   public override void OnPointerExit(PointerEventData ptrData){
   	textPopup.SetActive(false);
   }

}
