using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AZ05 : MonoBehaviour
{
    public GameObject item;
    public GameObject[] notItem;

    // Update is called once per frame
    void LateUpdate()
    {
        /*if(item.activeSelf == true){
            DisableGameObjects(notItem);
        }*/
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
}
