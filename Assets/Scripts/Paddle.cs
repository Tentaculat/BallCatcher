using UnityEngine;

public class Paddle : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(Model.instance.GetPaddleX(), transform.localPosition.y, transform.localPosition.z);
	}
}
