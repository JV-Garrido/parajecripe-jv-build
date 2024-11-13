using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	
	private static PauseScript instance;

	GameObject  pauseCanvas;
	GameObject canvas1;
	public bool isPause;
	public GameObject settingsCanvas;

	void Awake()
	{
		instance = this;
	}
	void Start(){
		
		pauseCanvas = GameObject.Find ("PauseCanvas");
		canvas1 = GameObject.Find ("Canvas1");
		pauseCanvas.SetActive(false);
	}
	
	
	
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.P)){
			PauseGame();
			isPause = true;
		}
	else
        {
			isPause = false;
		}
	}
	
	public void PauseGame(){
		
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			canvas1.SetActive(false);
		} 
		else if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			settingsCanvas.SetActive (false);
			canvas1.SetActive(true);
		}
	}
	
}
