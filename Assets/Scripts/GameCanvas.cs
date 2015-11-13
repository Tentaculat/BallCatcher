using UnityEngine;

public class GameCanvas : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Rect rect = GetComponent<RectTransform>().rect;
        Model.instance.SetScreenSize(rect.width, rect.height);
	}
}
