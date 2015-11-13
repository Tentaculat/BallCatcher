using UnityEngine;

public class MainController : MonoBehaviour {
    public string gameSceneName = "game";

    public void OnEnterButton() {
        Application.LoadLevel(gameSceneName);
    }

    public void OnExitButton() {
        Application.Quit();
    }
}
