using UnityEngine;
using UnityEngine.UI;
using NanoTimers;

public class MsgBanner : MonoBehaviour{

   public Text heading;
   public Text message;

   private CountdownTimer timer;

   void OnEnable(){
      if(timer) return;
      timer = gameObject.AddComponent<CountdownTimer>();
      timer.Initialize(new NanoTimers.Time(0, 0, 2300), OnTimerExpired);
   }

   public void SetMessage(string head, string msg){
      heading.text = head;
      message.text = msg;
   }

   public void Display(){
      gameObject.SetActive(true);
      timer.StartTimer();
   }

   private void OnTimerExpired(){
      gameObject.SetActive(false);
   }

}
