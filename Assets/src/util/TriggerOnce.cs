
public class TriggerOnce {
   private bool triggered;

   public TriggerOnce(bool state){
      this.triggered = state;
   }

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
