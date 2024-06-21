using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public float lifePoints { get; private set; } = 0f;
    public float points { get; private set; } = 0f;
    public int currentLevel { get; private set; } = 1;

    [SerializeField] public float pointsToLvlUp { get; private set; } = 100f;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetLifePoints(float value) => lifePoints += value;
    public void SetPoints(float value) => points += value;
    public void LevelUp() => currentLevel++;
    public void Reset()
    {
        lifePoints = 0f;
        points = 0f;
        currentLevel = 1;
    }

}
