
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sherlock : MonoBehaviour{

   public GameObject speechBubble;
   public Text bubbleText;

   public void DoSpeech(string fileName){
      speechBubble.SetActive(true);
      TextAsset text = Resources.Load<TextAsset>("sherlockDialogue/" + fileName);

      bubbleText.text = text.text;
   }

   public void DoReview(string text){
      speechBubble.SetActive(true);
      bubbleText.text = text;
   }

   public void Clear(){
      bubbleText.text = "";
   }

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

   private IEnumerator DoDialogue(){
      // TODO:
      // Write diaogue routine that displays a line or two, waits for user
      // input, then renders the next set of lines until end of file.

      yield break;
   }

}
