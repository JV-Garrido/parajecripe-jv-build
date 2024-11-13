using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMobileActive : MonoBehaviour
{
	public GameObject[] mobileControls;
    private void Start()
    {
#if MOBILE_INPUT
		EnableGameObjects(mobileControls);
#else
		DisableGameObjects(mobileControls);
#endif
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
