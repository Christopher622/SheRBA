using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Container of a list of InvSlot that holds items.

public class Inventory : DraggableObject {

	public bool isDraggable;
	public GameObject canvas;
	public MsgBanner msgBanner;
	public InvSlot[] slotList;

	void Start(){
		// Need to initialize each inventory slot object in this inventory.
		foreach(InvSlot slot in slotList){
			slot.msgBanner = msgBanner;
		}
	}

	void OnEnable(){
		// Need to initialize each inventory slot object in this inventory.
		foreach(InvSlot slot in slotList){
			if(!slot.msgBanner) slot.msgBanner = msgBanner;
		}
	}

	// Allows the inventory window to be draggable.
	public override void OnDrag(PointerEventData ptrData){
		if(!isDraggable) return;
      ptrData.pointerDrag.transform.position = Input.mousePosition;

		// TODO:
		// Window will always be centered on the cursor. Need to lock its position
		// relative to where the click event happened.
   }

	// Takes a reference to an existing GameObject and clones it into this
	// inventory.
	// Items being cloned need an Item component to be compatible.
	public void CreateItem(GameObject item){
		foreach(InvSlot slot in slotList){
			GameObject newItem;
			if(!slot.item && item.GetComponent<Item>()){
				newItem = GameObject.Instantiate(item);
				slot.item = newItem.GetComponent<Item>();
				slot.item.canvas = canvas;
				newItem.gameObject.transform.SetParent(slot.transform);
				newItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
				newItem.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
				newItem.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);

				return;
			}
			else if(!item.GetComponent<Item>()){
				Debug.LogError("GameObject has no item component.");
			}
		}

		Debug.LogWarning("Inventory is full.");
	}

}
