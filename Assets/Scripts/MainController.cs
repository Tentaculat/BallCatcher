using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {
    public string gameSceneName = "game";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEnterButton() {
        Application.LoadLevel(gameSceneName);
    }

    public void onExitButton() {
        Application.Quit();
    }
}
