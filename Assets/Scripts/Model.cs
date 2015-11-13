using UnityEngine;
using System.Collections.Generic;

public class Model {
    private const float paddleWidth = 100;
    private const float paddleSpeed = 1000;

    private const float startBallEmissionInterval = 2;
    private const float startBallSpeed = 100;
    private const float ballRadius = 50;

    private const float speedIncreaseInterval = 30;
    private const float speedMultiplier = 1.1f;

    private int counter;
    private float width;
    private float height;
    private float paddleCenterX;
    private float ballEmissionInterval;
    private float ballSpeed;
    private float timeToNewBall;
    private float timeToSpeedIncrease;

    
    public class Ball {
        public bool isLive;
        public float x;
        public float y;
        public float xSpeedCoefficient;

        public Ball(float x, float y, float xSpeedCoefficient) {
            this.isLive = true;
            this.x = x;
            this.y = y;
            this.xSpeedCoefficient = xSpeedCoefficient;
        }
    }

    private List<Ball> balls = new List<Ball>();
    private List<Ball> ballsToRemove = new List<Ball>();

    private static Model _instance = null;

    private Model() {
        Reset();
    }

    public static Model instance {
        get {
            if (_instance == null) {
                _instance = new Model();
            }
            return _instance;
        }
    }

    public void SetScreenSize(float width, float height) {
        this.width = width;
        this.height = height;
    }

    public int GetScore() {
        return counter;
    }

    public int GetBallCount() {
        return balls.Count;
    }

    public Ball GetBallByIndex(int index) {
        return (index >= 0 && index < balls.Count) ? balls[index] : null;
    }

    public float GetPaddleX() {
        return paddleCenterX;
    }

    public void Update(float dt, float paddleShiftDirection) {
        paddleCenterX = Mathf.Clamp(paddleCenterX + paddleShiftDirection * paddleSpeed * dt, -0.5f * width + 0.5f * paddleWidth, 0.5f * width - 0.5f * paddleWidth);

        timeToSpeedIncrease -= dt;
        if (timeToSpeedIncrease < 0) {
            timeToSpeedIncrease += speedIncreaseInterval;
            ballEmissionInterval /= speedMultiplier;
            ballSpeed *= speedMultiplier; 
        }

        timeToNewBall -= dt;
        if (timeToNewBall <= 0) {
            timeToNewBall += ballEmissionInterval;
            float ballX = Random.Range(-0.5f * width + ballRadius, 0.5f * width - ballRadius);
            float xSpeedCoefficient = Random.Range(-1, 1);
            balls.Add(new Ball(ballX, 0, xSpeedCoefficient));
        }

        bool isGameOver = false;

        foreach (Ball b in balls) {
            b.y += ballSpeed * dt;
            b.x += b.xSpeedCoefficient * ballSpeed * dt;

            if (b.x < -0.5f * width + ballRadius || b.x > 0.5f * width - ballRadius) {
                b.xSpeedCoefficient = -b.xSpeedCoefficient;
            }

            if (b.y > height) {
                ballsToRemove.Add(b);
                if (b.x > paddleCenterX - 0.5f * paddleWidth && b.x < paddleCenterX + 0.5f * paddleWidth) {
                    ++counter;
                } else {
                    isGameOver = true;
                }
            }
        }

        if (isGameOver) {
            Reset();
        } else {
            foreach (Ball b in ballsToRemove) {
                RemoveBall(b);
            }
            ballsToRemove.Clear();
        }
    }

    private void Reset() {
        counter = 0;
        paddleCenterX = 0;
        ballSpeed = startBallSpeed;
        ballEmissionInterval = startBallEmissionInterval;
        timeToNewBall = 0;
        timeToSpeedIncrease = speedIncreaseInterval;
        RemoveAllBalls();
    }

    private void RemoveBall(Ball b) {
        b.isLive = false;
        balls.Remove(b);
    }

    private void RemoveAllBalls() {
        foreach (Ball b in balls) {
            b.isLive = false;
        }
        balls.Clear();
        ballsToRemove.Clear();
    }
}
