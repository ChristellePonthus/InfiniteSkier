using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    //Références au joueur
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LifeBar lifeBar;
    [SerializeField] private MainCharacterController mainCharacter;
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        SaveData();
        if (scene.name == "GameOver" || scene.name == "Victory")
        {
            LoadData();
        }
    }


    private void SaveData()
    {
        SavedData savedData = new SavedData
        {
            savedCurrentLife = mainCharacter.currentLife,
            savedCurrentPoints = mainCharacter.currentPoints,
        };
        string directory = Application.persistentDataPath + "/Saves";

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        string jsonData = JsonUtility.ToJson(savedData);

        //Génération du fichier
        File.WriteAllText(directory + "/SavedData.json", jsonData);
    }
    public void LoadData()
    {
        string savedFilePath = Application.persistentDataPath + "/Saves/SavedData.json";
        if (File.Exists(savedFilePath))
        {
            string jsonData = File.ReadAllText(savedFilePath);
            SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);

            //Chargement des données
            mainCharacter.currentLife = savedData.savedCurrentLife;
            mainCharacter.currentPoints = savedData.savedCurrentPoints;
        }
        else
        {
            print("Le fichier n'existe pas !");
        }



    }
}

public class SavedData
{
    public float savedCurrentLife;
    public float savedCurrentPoints;
}