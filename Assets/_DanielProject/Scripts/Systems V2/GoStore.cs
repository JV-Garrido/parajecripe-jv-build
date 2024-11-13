using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoStore : MonoBehaviour
{
    public string sceneName;
 
    public void GoShop()
    {
        SceneManager.LoadScene(sceneName);
    }
}
