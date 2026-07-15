using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI ScoreCountStats;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        ScoreCountStats.text = gameManager.GetScore() + "\n" + gameManager.GetHighScore();
    }
}
