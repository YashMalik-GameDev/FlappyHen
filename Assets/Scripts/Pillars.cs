using Unity.VisualScripting;
using UnityEngine;

public class Pillars : MonoBehaviour
{

    private float moveSpeed = 3f;
    private float maxMovespeed = 5f;
    private int speedIncreaseAfterEveryPillars = 5;
    private float speedIncreaseAmount = 0.5f;

    private float destroyPositionX = -20f;

    private bool hasScored = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        
        if ( gameManager.GetGameOver() )
        {
            return;
        }

        int score = gameManager.GetScore();
        float currentSpeed = moveSpeed + ((score / speedIncreaseAfterEveryPillars) * speedIncreaseAmount);

        if ( currentSpeed > maxMovespeed )
        {
            currentSpeed = maxMovespeed;
        }

        transform.position += Vector3.left * currentSpeed * Time.deltaTime;
        if ( transform.position.x < -1f && !hasScored  )
        {
            gameManager.AddScore();
            hasScored = true;
        }

        if (transform.position.x < destroyPositionX)
        {
            Destroy(gameObject);
        }
    }



}
