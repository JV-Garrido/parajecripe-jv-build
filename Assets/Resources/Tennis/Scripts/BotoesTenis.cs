﻿using UnityEngine;
using System.Collections;

public class BotoesTenis : MonoBehaviour {

	
	public void LoadMenu(){
		Application.LoadLevel("PlayTennis");
	}

	public void Reload(){
		Application.LoadLevel (Application.loadedLevel);
	}

}
