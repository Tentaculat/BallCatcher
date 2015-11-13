using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public Text text;

	// Update is called once per frame
	void Update () {
        text.text = Model.instance.GetScore().ToString();
	}
}
