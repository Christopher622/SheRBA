using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayBtn : ClickableObject {

   public VideoPlayerConsole console;

   // TODO:
   // Replace with sprite/image.
   public Text btnText;

   public override void OnPointerClick(PointerEventData ptrData){
      base.OnPointerClick(ptrData);

      // if(console.videoPlayer.isPlaying){
      //    console.videoPlayer.Pause();
      // }
		// else{
      //    console.videoPlayer.Play();
      // }

      if(console.State == EVideoState.playing){
         console.State = EVideoState.paused;
      }
      else{
         console.State = EVideoState.playing;
      }

   }
}
