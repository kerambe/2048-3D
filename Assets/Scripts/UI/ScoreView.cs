using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    public void UpdateScore(long score)
    {
        _score.text = "Score: " + (score);
    }
}
