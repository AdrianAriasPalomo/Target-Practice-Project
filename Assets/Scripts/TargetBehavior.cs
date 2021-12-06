using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    protected int value = 1;

    private float RotateSpeed = 3f;
    private float Radius = 0.8f;

    protected Vector2 originalPos;
    private float angle;

    private void Start()
    {
        GoToRandomPosition();
    }

    private void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        GameManager.Instance.score += value;
        Debug.Log(GameManager.Instance.score);
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

    protected virtual void Move()
    {
        // Moves target in a circle
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = originalPos + offset;
    }
}
