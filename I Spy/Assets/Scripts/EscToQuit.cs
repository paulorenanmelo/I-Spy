using UnityEngine;

public class EscToQuit : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            if (Application.isPlaying) UnityEditor.EditorApplication.ExitPlaymode();
#endif
        }
    }
}