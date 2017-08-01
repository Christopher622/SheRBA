using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : DraggableObject, IDropHandler {

	public bool isDraggable;
	public GameObject canvas;
	public MsgBanner msgBanner;
	public InvSlot[] slotList;

	void Start(){
		foreach(InvSlot slot in slotList){
			slot.msgBanner = msgBanner;
		}
	}

	void OnEnable(){
		foreach(InvSlot slot in slotList){
			if(!slot.msgBanner) slot.msgBanner = msgBanner;
		}
	}

	public void OnDrop(PointerEventData ptrData){
		//ptrData.pointerDrag.GetComponent<Item>().newContainer = gameObject;
	}

	public override void OnDrag(PointerEventData ptrData){
		if(!isDraggable) return;
      ptrData.pointerDrag.transform.position = Input.mousePosition;
   }

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
