using UnityEngine;
using UnityEngine.EventSystems;

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

		curSlot = null;
      prevSlot = ptrData.pointerDrag.transform.parent.gameObject;
      ptrData.pointerDrag.transform.SetParent(canvas.transform);
   }

	public override void OnEndDrag(PointerEventData ptrData){
		base.OnEndDrag(ptrData);

		if(curSlot){
			ptrData.pointerDrag.transform.SetParent(curSlot.transform);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);

			if(prevSlot.GetComponent<InvSlot>())
			 	prevSlot.GetComponent<InvSlot>().item = null;

			prevSlot = null;

			//Debug.Log("Success");
		}
		else if(!curSlot){

			ptrData.pointerDrag.transform.SetParent(prevSlot.transform);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
			ptrData.pointerDrag.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);

			//Debug.Log("Failure");
		}

   }

}
