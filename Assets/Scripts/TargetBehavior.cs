using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private float RotateSpeed = 3f;
    private float Radius = 0.8f;

    protected Vector2 originalPos;
    private float angle;

    private void Start()
    {
        GoToRandomPosition();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnMouseDown()
    {
        GameManager.Instance.score ++;
        CheckHighScore();
        GoToRandomPosition();
    }

    private Vector2 GenerateRandomPosition()
    {
        float randomXPos = Random.Range(-7, 7);
        float randomYPos = Random.Range(-3, 3);
        return new Vector2(randomXPos, randomYPos);
    }

    private void GoToRandomPosition()
    {
        originalPos = GenerateRandomPosition();
        transform.position = originalPos;
    }

    private void CheckHighScore()
    {
        if (GameManager.Instance.score >= GameManager.Instance.highScore)
        {
            GameManager.Instance.highScore = GameManager.Instance.score;
        }
    }

    protected virtual void Move()
    {
        // Moves target in a circle
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = originalPos + offset;
    }
}
