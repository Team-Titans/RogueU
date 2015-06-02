using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {
    public void ChangeToScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
