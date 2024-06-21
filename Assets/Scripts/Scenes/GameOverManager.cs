using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pointsTFD;
    [SerializeField] private TMP_Text levelTFD;

    private void Start()
    {
        float points = GameController.instance.points;
        float level = GameController.instance.currentLevel;

        pointsTFD.text = "Points: " + points.ToString("F0");
        levelTFD.text = "Level: " + level.ToString("F0");

        GameController.instance.Reset();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
