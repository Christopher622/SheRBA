
using UnityEngine;

public class EvidenceDock : MonoBehaviour {

   public MsgBanner msgBanner;
   public GameObject canvas;
   public VideoPlayerConsole console;
   public Inventory inventory;
   public GameObject[] evidence;
   public double[] timeCues;

   private bool[] hasSpanwed;

   void Start(){
      hasSpanwed = new bool[evidence.Length];
   }

   void FixedUpdate(){
      for(int i = 0; i < evidence.Length; i++){
   		if(console.videoPlayer.time >= timeCues[i] && !hasSpanwed[i]){
            hasSpanwed[i] = true;
   			GameObject item = GameObject.Instantiate(evidence[i]);
            inventory.CreateItem(item);
   			item.transform.SetParent(transform);
            item.GetComponent<Item>().canvas = canvas;
            item.GetComponent<CanvasGroup>().blocksRaycasts = false;
            msgBanner.SetMessage("Discovery!", item.GetComponent<Item>().itemName + " has been added to your inventory.");
            msgBanner.Display();
   		}
   	}
   }
}
