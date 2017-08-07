
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Handles all of Sherlock's dialogue and triggerable events.

public class Sherlock : MonoBehaviour{

   public GameObject speechBubble;
   public Text bubbleText;

   // Displays the dialogue from a specific file.
   public void DoSpeech(string fileName){
      speechBubble.SetActive(true);
      TextAsset text = Resources.Load<TextAsset>("sherlockDialogue/" + fileName);

      bubbleText.text = text.text;
   }

   // Displays the dialogue from a string.
   public void DoReview(string text){
      speechBubble.SetActive(true);
      bubbleText.text = text;
   }

   public void Clear(){
      bubbleText.text = "";
   }

   // Iterates through the given list of inventories where Sherlock displays a
   // specific dialogue for each item and how it was classified.
   public void SubmitEvidence(Inventory[] invList){

      string text = "";
      int i = 0;

      foreach(Inventory inv in invList){
         foreach(InvSlot invSlot in inv.slotList){
            if(!invSlot.item) continue;
            switch(i){
               case 0:{
                  text += (" " + Resources.Load<TextAsset>("sherlockDialogue/theorySupportTest").text);
                  break;
               }
               case 1:{
                  text += (" " + Resources.Load<TextAsset>("sherlockDialogue/theoryRefuteTest").text);
                  break;
               }
               case 2:{
                  text += (" " + Resources.Load<TextAsset>("sherlockDialogue/theoryIrrelevant").text);
                  break;
               }
            }
         }
         i++;
      }

      DoReview(text);
   }

   // Coroutine that displays Sherlock's dialogue one line at a time until the
   // user gives input to continue. (WIP)
   private IEnumerator DoDialogue(){
      // TODO:
      // Write diaogue routine that displays a line or two, waits for user
      // input, then renders the next set of lines until end of file.

      yield break;
   }

}
