
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{

	public static GameManager inst;
	public static GameObject msgBanner;

	public GameObject canvas;

	//public GameObject mapModule;
	//public GameObject studyModule;
	public GameObject fadeFilter;
	//public VideoPlayer videoPlayer;

	private GameObject currentModule;
	public GameObject startModule;

	public void SetNewModule(GameObject module){
		fadeFilter.SetActive(true);
		RecursiveReset(currentModule);
		currentModule.SetActive(false);
		currentModule = module;
		module.SetActive(true);
		fadeFilter.SetActive(false);
	}

	void Start(){
		currentModule = startModule;
	}

	void Awake(){
		if(inst == null){
			inst = this;
		}
		else{
			Destroy(gameObject);
			return;
		}

	}

	private void RecursiveReset(GameObject node){

		if(node.GetComponent<IState>() != null)
			node.GetComponent<IState>().ResetState();

		//Debug.Log(node.name);

		if(node.transform.childCount == 0) return;

		for(int i = 0; i < node.transform.childCount; i++){
			RecursiveReset(node.transform.GetChild(i).gameObject);
		}
	}

}
