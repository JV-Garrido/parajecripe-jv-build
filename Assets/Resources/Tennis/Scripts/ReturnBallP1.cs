using UnityEngine;
using System.Collections;

public class ReturnBallP1 : MonoBehaviour {

	public GameObject target;
	
	private float timeToTarget;

	public bool isServing;
	private int side;
    
	TennisSounds TennisSounds;

	private Animator a;

	public float ballSpeed;
    
	public bool isTutorial;

	public bool isPlayer;
	//private EnemyController eController;

	private GameController gController;

	//private BallController bController;

	private float raquetadaBuffer;

	TennisTutorialController tutController;
	// Use this for initialization
	void Start () {
		//if(isTutorial == false){
			gController = GameObject.Find("GameController").GetComponent<GameController>();
			//bController = GameObject.Find("ball").GetComponent<BallController>();
			//eController = GameObject.Find("player2").GetComponent<EnemyController>();
		//}
		//else {
		//	tutController = GameObject.Find ("TennisTutorialController").GetComponent<TennisTutorialController>();
		//}
		TennisSounds = GameObject.Find ("Sounds").GetComponent<TennisSounds>();
		a = GetComponentInParent<Animator>();
		ballSpeed = 17f;
		if(isPlayer == false){
			side = -1;
		}
		else{
			side = 1;
		}
	}

	void OnTriggerEnter (Collider c){
		if (c.gameObject.tag == "animationTrigger" && isServing == false) {
			float rotationY = transform.eulerAngles.y;
			if(side == -1){
				rotationY += 180f;
				if(rotationY > 360){
					rotationY-=360;
				}
			}
			
			if (rotationY >= 135 && rotationY < 190) {
				a.SetTrigger ("Backhand_front");
			} else if (rotationY >= 190 && rotationY <= 225) {
				a.SetTrigger ("Forehand_front");
			}
			else if (rotationY < 135 && rotationY > 0) {
				a.SetTrigger ("Backhand_side");
			} else if (rotationY > 225 && rotationY <= 360) {
				a.SetTrigger ("Forehand_side");
			}
			
		}

		else if(c.gameObject.tag == "Ball"){
			if(isServing || !isPlayer){
				//if(isTutorial==false){
					gController.ResetBounce();
					if(isPlayer == true){
						gController.playerTurn = false;
					}
					else if(isPlayer == false){
						gController.playerTurn = true;
					}
                    /*
					if(isPlayer == true){
						eController.lookAtTarget = true;
					}
					else if(isPlayer == false){
						eController.interceptBall = false;
						eController.moveToDefault = true;
					}
                    */
				//}
				//else if(isTutorial == true){
				//	tutController.AddHit();
				//}
				TennisSounds.PlaySound(TennisSounds.ball);
				TennisSounds.PlaySound(TennisSounds.playerMoan);
				TennisSounds.PlaySound(TennisSounds.racket);

				
				if(isPlayer == true && !isServing){
					float playerRot = transform.eulerAngles.y;
					float x=0;

					if(playerRot>=0 && playerRot<90){
						x = playerRot/25;
					}
					else if(playerRot>=90 && playerRot<=270){
						x = (180-playerRot)/25;
					}
					else if (playerRot>270 && playerRot<=360){
						x = -(360-playerRot)/25;
					}
					float z = (transform.position.z /4.4f) + 8.1f;
					Vector3 playerTargetPos = new Vector3(-x, 0f, z);
					target.transform.position = playerTargetPos;
				}
				

				//ballSpeed = ballSpeed * 0.9f;

				timeToTarget = (target.transform.position - transform.position).magnitude/ballSpeed;
				if(!isPlayer) timeToTarget = timeToTarget * -1;
				c.attachedRigidbody.velocity = side*Velocidade(timeToTarget);
				
				/*
				if(!isServing){				
					ballSpeed = 14.85f;
				}
				*/
			}
			
			else if(isPlayer)
			{
					//if(isTutorial==false){
						gController.ResetBounce();
						if(isPlayer == true){
							gController.playerTurn = false;
						}
						else if(isPlayer == false){
							gController.playerTurn = true;
						}
                        /*
						if(isPlayer == true){
							eController.lookAtTarget = true;
						}
						else if(isPlayer == false){
							eController.interceptBall = false;
							eController.moveToDefault = true;
						}
                        */
					//}
					//else if(isTutorial == true){
					//	tutController.AddHit();
					//}
					
					TennisSounds.PlaySound(TennisSounds.ball);
					TennisSounds.PlaySound(TennisSounds.playerMoan);
					TennisSounds.PlaySound(TennisSounds.racket);


					if(/*isPlayer == true && */!isServing){
						float playerRot = transform.eulerAngles.y;
						float x=0;

						if(playerRot>=0 && playerRot<90){
							x = playerRot/25;
						}
						else if(playerRot>=90 && playerRot<=270){
							x = (180-playerRot)/25;
						}
						else if (playerRot>270 && playerRot<=360){
							x = -(360-playerRot)/25;
						}
						float z = (transform.position.z /4.4f) + 8.1f;
						Vector3 playerTargetPos = new Vector3(-x, 0f, z);
						target.transform.position = playerTargetPos;
					}

					//ballSpeed = ballSpeed * 0.9f;

					timeToTarget = (target.transform.position - transform.position).magnitude/ballSpeed;
					
					if(isPlayer == false){
						timeToTarget = timeToTarget * -1;
					}
					
					c.attachedRigidbody.velocity = side*Velocidade(timeToTarget);
					
					/*
					if(!isServing){				
						ballSpeed = 14.85f;
					}
					*/
			}
			//original speed: 14.85
			//trying speed: 11.88
			/*if(!isServing)*/ ballSpeed = 7.425f;
			//c.attachedRigidbody.SetServed(false);
			//bController.SetServed(true);
			//c.attachedRigidbody.AddForce(Vector3.down * 4.905f);
		}
	}

/*
	void Update(){
		if (SimpleInput.GetKeyDown(KeyCode.Space) && raquetadaBuffer <= 0 && isPlayer){
		
				float rotationY = transform.eulerAngles.y;
				if(side == -1){
					rotationY += 180f;
					if(rotationY > 360){
						rotationY-=360;
					}
				}
				
				if (rotationY >= 135 && rotationY < 190) {
					a.SetTrigger ("Backhand_front");
				} else if (rotationY >= 190 && rotationY <= 225) {
					a.SetTrigger ("Forehand_front");
				}
				else if (rotationY < 135 && rotationY > 0) {
					a.SetTrigger ("Backhand_side");
				} else if (rotationY > 225 && rotationY <= 360) {
					a.SetTrigger ("Forehand_side");
				}

				raquetadaBuffer = 0.8f;
		}
		if (raquetadaBuffer > 0){
			raquetadaBuffer -= Time.deltaTime;
		}
	}
*/
	Vector3 Velocidade(float timeToHit) {
		Vector3 distance = target.transform.position - transform.position;
		Vector3 direction = distance;
		direction.y = 0;
		
		float y = distance.y;
		float xz = direction.magnitude;
		
		float t = timeToHit;
		float v0y = (y / t + 0.5f * Physics.gravity.magnitude * t) /* / 2f*/;
		float v0xz = xz / t;
		
		Vector3 result = direction.normalized;        
		result *= v0xz;                                
		result.y = v0y;                                
		
		return result;
	}

}