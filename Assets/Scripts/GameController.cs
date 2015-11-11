using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public Transform paddle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            paddle.Translate(-100 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            paddle.Translate(100 * Time.deltaTime, 0, 0);
        }

    }
}
