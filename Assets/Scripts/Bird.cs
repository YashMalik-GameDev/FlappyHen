using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{

    private Rigidbody2D birdRigidbody2D;
    private float jumpForce = 10f;

    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
         birdRigidbody2D = GetComponent<Rigidbody2D>();
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
            birdRigidbody2D.linearVelocity = Vector2.up * jumpForce;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }
    }

}
