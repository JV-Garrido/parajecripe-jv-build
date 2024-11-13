using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            DeleteAllPlayerPrefs();
            Debug.Log("Delete");
        }
    }
}
