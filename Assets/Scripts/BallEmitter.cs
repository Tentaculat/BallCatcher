using UnityEngine;

public class BallEmitter : MonoBehaviour {
    public Transform ballPrefab;

// Update is called once per frame
    void Update () {
        int ballCount = Model.instance.GetBallCount();
        while (transform.childCount < ballCount) {
            Model.Ball b = Model.instance.GetBallByIndex(transform.childCount);

            Transform ball = (Transform)Instantiate(ballPrefab, new Vector3(b.x, -b.y, 0), Quaternion.identity);
            ball.SetParent(transform, false);
            ball.GetComponent<Ball>().SetBall(b);
        }
    }
}
