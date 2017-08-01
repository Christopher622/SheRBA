using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VideoSlider : ClickableObject{

   public VideoPlayerConsole console;
   public Slider timeLine;

   private EVideoState prevState;

   public override void OnPointerDown(PointerEventData ptrData){
      base.OnPointerDown(ptrData);

      if(!timeLine.interactable) return;

      prevState = console.State;
      console.State = EVideoState.seeking;
   }

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
