
// Flow control that allows a block of code to only be triggered once.

public class TriggerOnce {
   private bool triggered;

   public TriggerOnce(bool state){
      this.triggered = state;
   }

   // Returns false if this trigger hasn't already been triggered.
   // Best used in an if-statement.
   /*
      if(!TriggerOnceInstance.Trigger()){
         // Do one-time code execution
      }
   */

   public bool Trigger(){
      if(triggered){
         return true;
      }
      else{
         triggered = true;
         return false;
      }
   }

   public void Reset(){
      triggered = false;
   }
}
