using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Datas/ObstacleData")]
public class ObstacleData : ScriptableObject
{
    public GameObject prefab;
    public float damages;

    void Update() 
    {
        var currentLevel = GameController.instance.currentLevel;
        if (currentLevel > 1)
            damages += damages * 0.2f;
    }
}
