using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class VideoPlayerConsole : MonoBehaviour {

	// ** Video player constants **
	const int VID_WIDTH = 1280;
	const int VID_HEIGHT = 720;
	const int VID_CDEPTH = 24;

	// ** Outside References **
	public VideoPlayer videoPlayer;
	public RawImage videoRenderer;
	public AudioSource audioSource;
	public GameObject pauseFilter;
	public Text btnText;
	public Text timeText;
	public Slider timeLine;

	// ** Debugging **
	[Header("Debugging")]
	public Text debugTimeText;
	public Text debugFrameText;


	// Access through the property so TriggerOnce can be reset properly.
	private EVideoState state = EVideoState.paused;

	// Keep track of when a state has bene triggered.
	private TriggerOnce triggerOnce = new TriggerOnce(false);

	public EVideoState State{
		get{
			return state;
		}
		set{
			state = value;
			triggerOnce.Reset();
		}
	}

	void Start(){
		RenderTexture rendTex =
			new RenderTexture(VID_WIDTH, VID_HEIGHT, VID_CDEPTH);

		if(!videoPlayer.clip){
			Debug.LogError(videoPlayer.name + " " + videoPlayer.GetInstanceID() + " has no video clip.");
			this.enabled = false;
			return;
		}

		videoRenderer.texture = rendTex;
		videoPlayer.targetTexture = rendTex;

		videoPlayer.Prepare();
		videoPlayer.StepForward();

		timeText.text =
			FormatTime((int)videoPlayer.time) + " / " + FormatTime((int)videoPlayer.clip.length);
	}

	void FixedUpdate(){

		//debugTimeText.text = videoPlayer.time.ToString();
		//debugFrameText.text = videoPlayer.frame.ToString();

		if(videoPlayer.time >= videoPlayer.clip.length){
			State = EVideoState.stopped;
		}

		switch(state){
			case EVideoState.stopped:{

				// User has watched the video fully when this state is triggered.

				if(triggerOnce.Trigger()) break;

				pauseFilter.SetActive(true);
				btnText.text = ">";
				videoPlayer.frame = 0;
				videoPlayer.StepForward();

				timeLine.interactable = true;

				timeText.text =
					FormatTime((int)videoPlayer.time) + " / " + FormatTime((int)videoPlayer.clip.length);
				timeLine.value = (float)videoPlayer.time / (float)videoPlayer.clip.length;

				break;
			}

			case EVideoState.paused:{

				if(triggerOnce.Trigger()) break;

				videoPlayer.Pause();
				pauseFilter.SetActive(true);
				btnText.text = ">";

				break;
			}

			case EVideoState.playing:{

				if(triggerOnce.Trigger()){
					videoPlayer.Play();
					pauseFilter.SetActive(false);
					btnText.text = "ll";
				}

				if(videoPlayer.isPlaying){
					timeText.text =
						FormatTime((int)videoPlayer.time) + " / " + FormatTime((int)videoPlayer.clip.length);
					timeLine.value = (float)videoPlayer.time / (float)videoPlayer.clip.length;
				}

				break;
			}

			case EVideoState.seeking:{
				if(triggerOnce.Trigger()){
					videoPlayer.Pause();
					pauseFilter.SetActive(false);
				}

				double sliderTime = (timeLine.value * (float)videoPlayer.clip.length);

				timeText.text =
					FormatTime((int)sliderTime) + " / " + FormatTime((int)videoPlayer.clip.length);

				// TODO:
				// Update renderer.

				// NOTE:
				// As of 2017-07-24, there is not an effective way to seek and update
				// to a current frame in the API. The only way to render a frame
				// is to call Play() or StepForward(), which the latter would just
				// cause the video to basically play without sound in this loop.
				//
				// This seek state works as intended, however the visual frame will
				// not update until the user is done seeking.

				break;
			}
		}
	}

	// Takes in seconds and formats to a string in minutes and seconds.
	static string FormatTime(int time){
		int minutes = 0;

		while(time > 60){
			time -= 60;
			minutes += 1;
		}

		string minStr;
		string secStr;

		if(minutes < 10)
			minStr = "0" + minutes.ToString();
		else
			minStr = minutes.ToString();

		if(time < 10)
			secStr = "0" + time.ToString();
		else
			secStr = time.ToString();

		return minStr + ":" + secStr;
	}

}
