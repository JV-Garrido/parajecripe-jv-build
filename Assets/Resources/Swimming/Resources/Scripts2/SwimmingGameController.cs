using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class SwimmingGameController : MonoBehaviour
{
	
	[Header("Coin Manager")]
	public CoinManager coinManager;
	public int coinPrimeiroLugar;
	public int coinGameOver;
	[Header("Ui")]
	public GameObject uI;
	public GameObject pauseCanvas;
	public GameObject gameOverCanvas;
	public GameObject winnerBoard;
	public GameObject gameOverTextBox;
	public GameObject result;
	public Text gameOverTitle;
	public Text gameOverText;
	public Text pointText;
	public Text place1;
	public Text place2;
	public Text place3;
	[Header("Game Controller")]
	public bool isMasculine = true;
	public bool b1 = false;
	public bool inWater;
	public Timer at;
	public FallingCoin fc;
	public SwimmingSounds sounds;
	public GameObject player;
	public GameObject op1;
	public GameObject op1parent;
	public GameObject op2;
	public GameObject op2parent;
	public GameObject firstPlace;
	public GameObject secondPlace;
	public GameObject thirdPlace;
	public GameObject positionstext;
	public GameObject settingsCanvas;
	public GameObject OponentsParticleSystem;	
	public ParticleSystem pLeft;
	public ParticleSystem pRight;
	public float rotateNew;
	//Privates
	Vector3 maxvel;
	Vector3 movement;
	string lastSide;
	int points;	
	int armStrokeCount;
	Vector3 rotationVector;

	//Legacy
	private StoreDataContainer sD;

	void Start()
	{

		uI.SetActive(true);

		pauseCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);

		maxvel = new Vector3(0.0f, 0.0f, 3);
		movement = new Vector3(0, 0, 11);
		armStrokeCount = 0;

		if (isMasculine)
		{
            rotationVector.x = 0;
            rotationVector.y = 180;
        }
		else
		{
            rotationVector.x = 75;
            rotationVector.y = 0;
            rotationVector.x = rotateNew;
            rotationVector.y = 0;
        }
        //rotationVector.z = 0;

        points = 0;
		lastSide = "left";
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow) && inWater)
		{
			ArmStroke("left", "leftArmStrokeTrigger");
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow) && inWater)
		{
			ArmStroke("right", "rightArmStrokeTrigger");
		}
		else if (Input.GetKeyDown(KeyCode.P))
		{
			PauseGame();
		}
		//Mobile
#if MOBILE_INPUT
		else if (CrossPlatformInputManager.GetButtonDown("P"))
		{
			PauseGame();
		}
		//Mobile
		if (CrossPlatformInputManager.GetButtonDown("LeftArrow") && inWater)
		{
			ArmStroke("left", "leftArmStrokeTrigger");
		}
		else if (CrossPlatformInputManager.GetButtonDown("RightArrow") && inWater)
		{
			ArmStroke("right", "rightArmStrokeTrigger");
		}
#endif
		////rotationVector.x = 0;
	}

	void ArmStroke(string thisSide, string sideTrigger)
	{
		if (player.GetComponent<Rigidbody>().velocity.z < maxvel.z
			&& at.time <= 2f
			&& (lastSide != thisSide || armStrokeCount == 0))
		{

			player.GetComponent<Animator>().SetTrigger(sideTrigger);
			MoveForward();
			at.SetTimer();
			sounds.ArmStrokeSound();
			lastSide = thisSide;
			addPoints(10);
			armStrokeCount++;
			WaterParticleSystem(thisSide);


            //player.GetComponent<Transform>().eulerAngles = new Vector3(0,0,0);
            player.transform.rotation = Quaternion.Euler(rotationVector);
            //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;


        }
		else
		{
			at.ResetTimer();
		}

	}


	void WaterParticleSystem(string side)
	{

		if (side == "left")
		{
			pLeft.Play();
		}
		else
		{
			pRight.Play();
		}
	}


	void MoveForward()
	{
		player.GetComponent<Rigidbody>().AddForce(movement * 13);
		Debug.Log(player.GetComponent<Rigidbody>().velocity);
	}

	void addPoints(int addPoints)
	{
		//points += addPoints;
		//pointText.text = points.ToString();
		//fc.coinFallAnimation();
		//sD = StoreDataContainer.Load();
		//sD.storeObjects[0].coin += addPoints;
		//sD.Save();

	}

	public void StartGame()
	{


		b1 = true;
		Time.timeScale = 1;
		setOponentsAnimation();
		player.GetComponent<Animator>().SetTrigger("Jump");
		GameObject.Find("Player").GetComponent<Animator>().SetBool("jumpp", true);
		if (isMasculine)
		{
			GameObject.Find("PlayerParent").GetComponent<Animator>().SetTrigger("Jump");
			sounds.WaitPlay(1f, sounds.dive);
		}
		else
		{
			player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 250f));
		}
		positionstext.SetActive(true);
		OponentsParticleSystem.SetActive(true);


	}

	public void GameOver(int place)
	{

		//canvas1.SetActive (false);
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
		gameOverTextBox.SetActive(false);
		if (place == 1)
		{
			gameOverTitle.text = "VOCÊ VENCEU!!!";
			sounds.PlaySound(sounds.applause);
			addPoints(1000);
			coinManager.AddCoins(coinPrimeiroLugar);
			result.GetComponentInChildren<Text>().text = "Você ganhou " + coinPrimeiroLugar.ToString("0") + " moedas!";
		}
		else
		{
			gameOverTitle.text = "FIM DE JOGO";
			if (place == 2)
			{
				addPoints(700);
				coinManager.AddCoins(coinGameOver);
				result.GetComponentInChildren<Text>().text = "Você ganhou " + coinGameOver.ToString("0") + " moedas!";
			}
		}

		ChangeName();
		place1.text = firstPlace.name;
		place2.text = secondPlace.name;
		place3.text = thirdPlace.name;
		positionstext.SetActive(false);
		


	}

	void ChangeName()
	{

		if (firstPlace.name == "Player")
		{
			if (isMasculine)
				firstPlace.name = "Clodoaldo Silva";
			else
				firstPlace.name = "Edênia Garcia";
		}
		else if (secondPlace.name == "Player")
		{
			if (isMasculine)
				secondPlace.name = "Clodoaldo Silva";
			else
				secondPlace.name = "Edênia Garcia";
		}
		else if (thirdPlace.name == "Player")
		{
			if (isMasculine)
				thirdPlace.name = "Clodoaldo Silva";
			else
				thirdPlace.name = "Edênia Garcia";
		}


	}

	public void GameOver(bool noMoreOxygen)
	{
		result.SetActive(false);
		uI.SetActive(false);
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
		winnerBoard.SetActive(false);
		gameOverTitle.text = "O OXIGÊNIO ACABOU!";
		gameOverText.text = "Use a tecla ESPAÇO para respirar!\nNade outra vez!";
		positionstext.SetActive(false);

		//sD = StoreDataContainer.Load();
		//sD.storeObjects[0].coin += points;
		//sD.Save();
	}

	public void PauseGame()
	{

		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			uI.SetActive(false);
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			uI.SetActive(true);
			settingsCanvas.SetActive(false);
		}
	}
	//Oponents Animation
	public void setOponentsAnimation()
	{


		int r = Random.Range(0, 1);
		Debug.Log(r);

		setJumpTrigger(op1);
		setJumpTrigger(op2);

		if (isMasculine)
		{

			setJumpTrigger(op1parent);
			setJumpTrigger(op2parent);

			if (r == 1)
			{
				op1parent.GetComponent<Animator>().SetInteger("Rand", 1);
				op2parent.GetComponent<Animator>().SetInteger("Rand", 0);
			}
			else
			{
				op2parent.GetComponent<Animator>().SetInteger("Rand", 0);
				op1parent.GetComponent<Animator>().SetInteger("Rand", 1);
			}

		}

	}

	void setJumpTrigger(GameObject go)
	{
		go.GetComponent<Animator>().SetTrigger("JumpOp1");
	}


}

