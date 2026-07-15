using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI instructionText;
    private float blinkSpeed = 3f;
    private float minimumAlpha = 0.3f;

    private void Update()
    {
        Color color = instructionText.color;

        color.a = Mathf.Lerp(minimumAlpha, 1f, (Mathf.Sin(Time.time * blinkSpeed) + 1f) / 2f);

        instructionText.color = color;
    }



}
