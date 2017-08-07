using UnityEngine;
using UnityEngine.EventSystems;

// Base item class for objects that can be stored in an inventory window and can be
// dragged around.

public class Item : DraggableObject{

	public string itemName;
	public GameObject canvas;

	[HideInInspector]
	public GameObject curSlot;
	[HideInInspector]
   public GameObject prevSlot;

	[Tooltip("Name of the text file that holds Sherlock's relevant dialogue.")]
	public string appraisalSpeech;

	public override void OnBeginDrag(PointerEventData ptrData){
		base.OnBeginDrag(ptrData);

		// When an item is being dragged, its parent variable needs to be set to the
		// highest parent in the hierachy so it may render ontop of everything else,
		// which would be the canvas in this case.

		// The item's current slot reference needs to be cleared when being dragged
		// and saved to another variable in case a drag and drop operation fails.

		curSlot = null;
      prevSlot = ptrData.pointerDrag.transform.parent.gameObject;
      ptrData.pointerDrag.transform.SetParent(canvas.transform);
   }

	public override void OnEndDrag(PointerEventData ptrData){
		base.OnEndDrag(ptrData);

		// If this item's current slot has been set from OnDrop, then set this item's
		// parent to the slot and adjust it's alignment.

		if(curSlot){
			ptrData.pointerDrag.transform.SetParent(curSlot.transform);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);

			// Clear the item refernce from the prevvious slot because it doens't
			// belong there anymore.

			if(prevSlot.GetComponent<InvSlot>())
			 	prevSlot.GetComponent<InvSlot>().item = null;

			// Clear the previous slot of this item because the operation was successful.

			prevSlot = null;

			//Debug.Log("Success");
		}
		else if(!curSlot){

			// Another item already exists in the slot this item is trying to be dragged into.
			// Snap the item back to the last slot it was in.

			ptrData.pointerDrag.transform.SetParent(prevSlot.transform);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);

			//Debug.Log("Failure");
		}

   }

}
