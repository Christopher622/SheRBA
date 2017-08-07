using UnityEngine;
using UnityEngine.UI;
using NanoTimers;

// Displays a timed GUI alert or message.

public class MsgBanner : MonoBehaviour{

   public Text heading;
   public Text message;

   private CountdownTimer timer;

   // Creates and initializes the timer if one doesn't already exist.
   void OnEnable(){
      if(timer) return;
      timer = gameObject.AddComponent<CountdownTimer>();
      timer.Initialize(new NanoTimers.Time(0, 0, 2300), OnTimerExpired);
   }

   // Sets the message banner content.
   public void SetMessage(string head, string msg){
      heading.text = head;
      message.text = msg;
   }

   // Turns on the message and starts the timer.
   public void Display(){
      gameObject.SetActive(true);
      timer.StartTimer();
   }

   // Timer event that turns off the message.
   private void OnTimerExpired(){
      gameObject.SetActive(false);
   }

}
