
using UnityEngine;

// Item container that generates the items at specific time cues for the user's
// inventory while the video plays.

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

      // When the video time line is great than a given time cue for an item that
      // hasn't spawned yet, create that item for the user's inventory, spawn it for
      // the dock, and tell MsgBanner to show an alert.

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
