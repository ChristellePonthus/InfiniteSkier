using UnityEngine;
using TMPro;

public class PointsCounterUI : MonoBehaviour
{
    private TMP_Text pointsCounter;
    void Start()
    {
        pointsCounter = GetComponent<TMP_Text>();
    }

    public void UpdatePoints(float points)
    {
        pointsCounter.text = "Points: " + points.ToString("F0");
    }
}
