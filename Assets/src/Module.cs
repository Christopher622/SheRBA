using UnityEngine;

public class Module : MonoBehaviour{

	public GameObject sherlock;

	void OnEnable(){
		sherlock.SetActive(true);
   }

	void OnDisable(){
		sherlock.SetActive(false);
	}

}
