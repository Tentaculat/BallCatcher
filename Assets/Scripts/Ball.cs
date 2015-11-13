using UnityEngine;

public class Ball : MonoBehaviour {
    private Model.Ball b;

    public void SetBall(Model.Ball b) {
        this.b = b;
    }

	// Update is called once per frame
	void Update () {
        if (b.isLive) {
            transform.localPosition = new Vector3(b.x, -b.y, 0);
        } else {
            Destroy(gameObject);
        }
	}
}
