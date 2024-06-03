using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public float distance { get; private set; } = 0f;
    public float lifePoints { get; private set; } = 0f;
    public int currentLevel { get; private set; } = 1;


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

    public void SetLife(float value) => lifePoints += value;
    public void SetDistance(float value) => distance = value;
    public void LevelUp() => currentLevel++;

    public void Reset()
    {
        lifePoints = 0f;
        distance = 0f;
        currentLevel = 1;
    }

}
