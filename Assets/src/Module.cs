using UnityEngine;

// Logic controller for modules that toggle Sherlock's appearance.

public class Module : MonoBehaviour{

	public GameObject sherlock;

	void OnEnable(){
		sherlock.SetActive(true);
   }

	void OnDisable(){
		sherlock.SetActive(false);
	}

}
