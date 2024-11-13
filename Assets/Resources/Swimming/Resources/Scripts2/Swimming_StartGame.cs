using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Swimming_StartGame : MonoBehaviour {

	[Header("Mobile UI")]
	public bool useMobile;
	public GameObject[] mobileControlls;

	public GameObject text1;
	SwimmingSounds sounds;
	Timer t;

	public bool b = false;
    private void Awake()
    {
#if MOBILE_INPUT
		useMobile = true;
#else
		useMobile = false;
#endif
	}
	void Start(){
	
		text1.SetActive(false);
		Time.timeScale = 1;
		sounds = GameObject.Find("SwimmingSounds").GetComponent<SwimmingSounds>();
		t = GetComponent<Timer> ();
		
		if(useMobile == false)
        {
			DisableGameObjects(mobileControlls);
		}
		if (useMobile == true)
		{
			EnableGameObjects(mobileControlls);
		}
	}
	
	void Update () {
		
		if (Time.timeSinceLevelLoad >= 1 && Time.timeSinceLevelLoad < 2) {
		
			text1.SetActive (true);
		
		} else if (Time.timeSinceLevelLoad >= 2 && Input.GetKeyDown (KeyCode.Space)) {

			b = true;
			GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController> ().StartGame ();
			text1.SetActive (false);
			GameObject.Find ("Intro").SetActive (false);
			sounds.PlaySound (sounds.background);
			sounds.PlaySound (sounds.backgroundPeople);

			t.SetTimer ();

		}
#if MOBILE_INPUT
		else if (Time.timeSinceLevelLoad >= 2 && CrossPlatformInputManager.GetButtonDown("Space"))
		{

			b = true;
			GameObject.Find("SwimmingController").GetComponent<SwimmingGameController>().StartGame();
			text1.SetActive(false);
			GameObject.Find("Intro").SetActive(false);
			sounds.PlaySound(sounds.background);
			sounds.PlaySound(sounds.backgroundPeople);

			t.SetTimer();

		}
#endif
		else if (t.time >= 1.12f) {

			t.ResetTimer ();
			this.gameObject.SetActive (false);
			GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController> ().inWater = true;

		}
	
	}

	void DisableGameObjects(GameObject[] gameObjects)
	{
		for (int i = 0; i < gameObjects.Length; i++)
		{
			if (gameObjects[i] != null)
			{
				gameObjects[i].SetActive(false);
			}
		}
	}
	void EnableGameObjects(GameObject[] gameObjects)
	{
		for (int i = 0; i < gameObjects.Length; i++)
		{
			if (gameObjects[i] != null)
			{
				gameObjects[i].SetActive(true);
			}
		}
	}
}
