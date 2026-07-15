using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{

    private Rigidbody2D birdRigidbody2D;
    private float jumpForce = 10f;
    private float originalGravityScale;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
         birdRigidbody2D = GetComponent<Rigidbody2D>();
         originalGravityScale = birdRigidbody2D.gravityScale;
         birdRigidbody2D.gravityScale = 0f;
    }

    private void Update()
    {
        if (gameManager.GetGameOver())
        {
            return;
        }

        if (Keyboard.current.upArrowKey.wasPressedThisFrame ||
            Keyboard.current.spaceKey.wasPressedThisFrame ||
            Keyboard.current.wKey.wasPressedThisFrame)
        {
            if (!gameManager.GetGameStarted())
            {
                gameManager.StartGame();
                birdRigidbody2D.gravityScale = originalGravityScale;
            }

            birdRigidbody2D.linearVelocity = Vector2.up * jumpForce;
            soundManager.PlayJumpSound();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (gameManager.GetGameOver())
            {
                return;
            }
            soundManager.PlayHitSound();
            if (gameManager.GetScore() == 0)
            {
                soundManager.PlayShameSound();
            }
            else
            {
                soundManager.PlayCrashSound();
            }
            soundManager.StopBackgroundMusic();
            gameManager.GameOver();

        }
    }

}
