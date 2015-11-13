using UnityEngine;

public class GameController : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        float paddleShiftDirection = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            paddleShiftDirection -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            paddleShiftDirection += 1;
        }

        Model.instance.Update(Time.deltaTime, paddleShiftDirection);
    }
}
