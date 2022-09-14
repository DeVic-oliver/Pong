using UnityEngine;
using UnityEditor;

public class GameCloseHandler : MonoBehaviour
{
    public void CloseGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
