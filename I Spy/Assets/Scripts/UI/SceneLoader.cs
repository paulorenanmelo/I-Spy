using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName)) return;
        //if (!SceneManager.GetSceneByName(sceneName).IsValid()) return;
        SceneManager.LoadScene(sceneName);
    }
}
