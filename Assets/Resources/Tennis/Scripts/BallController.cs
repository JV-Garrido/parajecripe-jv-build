﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	
	private static Rigidbody r;
	public bool ballShooter;
	public bool isServing;
	private static float servingTime=Mathf.Infinity;
	private float timeSinceStart;

/*
	public bool served;

	public bool changedGrav;
	*/

	void Start () {
		r = GetComponent<Rigidbody> ();
		if (ballShooter == true) {
			r.useGravity = true;
			r.velocity = new Vector3 (Random.Range (-3, 3), Random.Range (5f, 5.3f), Random.Range (-14, -12));
			Destroy (gameObject, 30);
		} 
		//served = false;
		//changedGrav = false;
	}

	public static void ThrowBall(){
		
		servingTime = Time.time + 0.84f;
		r.velocity = new Vector3(-0.06f, -0.31f, -0.04f);
	}
	
	void Update () {
		if (isServing == true) {
			r.useGravity = false;
			r.velocity = Vector3.zero;

			if(Time.time> servingTime){				
				r.useGravity = true;
				r.velocity = new Vector3(0f, 4.7f, 0f);
				isServing = false;
				servingTime = Mathf.Infinity;
			}
		}
		//if (served/* && !changedGrav*/) {
		//	UpdateGravity();
		//}
		//Debug.Log(r.velocity);
	}

/*
	public void UpdateGravity(){
		r = GetComponent<Rigidbody> ();
		r.useGravity = false;
		r.AddForce(Vector3.up * -1.905f, ForceMode.Acceleration);
		changedGrav = true;
	}

	public bool GetServed(){
		return served;
	}

	public void SetServed(bool stat){
		served = stat;
	}
	*/
}



