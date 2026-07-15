using System.Threading;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{

    [SerializeField] GameObject pillarPairPrefab;
    [SerializeField] GameManager gameManager;

    private float spawnTime = 2f;
    private float minSpawnTime = 1.2f;
    private int spawnTimeDecreaseAfterEveryPillars = 5;
    private float spawnTimeDecreaseAmount = 0.2f;

    private float timer;

    private float[] gapsPositioning =
    {
        -4f,-3f,-2f,-1f,0f,1f,2f,3f,4f
    };

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }


    private void pillarSpawner()
    {
        int randomIndex = Random.Range (0, gapsPositioning.Length);
        float randomY = gapsPositioning[randomIndex];
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        Instantiate (pillarPairPrefab, spawnPosition, Quaternion.identity);
    }

    private void Update()
    {
    
        if (!gameManager.GetGameStarted())
        {
            return;
        }

        int score = gameManager.GetScore();
        float currentSpawnTime = spawnTime - ((score /  spawnTimeDecreaseAfterEveryPillars) * spawnTimeDecreaseAmount);

        if (currentSpawnTime < minSpawnTime)
        {
            currentSpawnTime = minSpawnTime;
        }

        timer += Time.deltaTime;

        if (timer >= currentSpawnTime)
        {
            pillarSpawner();
            timer = 0;
        }
    }

    

}
