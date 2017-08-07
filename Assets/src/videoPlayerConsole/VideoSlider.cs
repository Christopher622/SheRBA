using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Control logic for the video player when the time slider is interacted with.

public class VideoSlider : ClickableObject{

   public VideoPlayerConsole console;
   public Slider timeLine;

   private EVideoState prevState;

   // Change the video player state to seeking.
   public override void OnPointerDown(PointerEventData ptrData){
      base.OnPointerDown(ptrData);

      // User has to watch the complete video before seeking becomes avaliable.
      if(!timeLine.interactable) return;

      prevState = console.State;
      console.State = EVideoState.seeking;
   }

   // Update the current frame and set the video player back to the previous state.
   public override void OnPointerUp(PointerEventData ptrData){
      base.OnPointerUp(ptrData);

      if(!timeLine.interactable) return;

      console.videoPlayer.frame =
         (int)(timeLine.value * console.videoPlayer.clip.frameCount);

      // console.videoPlayer.time =
      //    (double)(timeLine.value * (float)console.videoPlayer.clip.length);

      console.State = prevState;
   }

   // Override to stop base call.
   public override void OnPointerEnter(PointerEventData ptrData){}

   // Override to stop base call.
   public override void OnPointerExit(PointerEventData ptrData){}
}
