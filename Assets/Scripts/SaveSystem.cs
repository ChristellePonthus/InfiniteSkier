using System;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //Références au joueur
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LifeBar lifeBar;
    [SerializeField] private MainCharacterController mainCharacter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SaveData();

        if (Input.GetKeyDown(KeyCode.F9))
            LoadData();
    }


    private void SaveData()
    {
        SavedData savedData = new SavedData
        {
            playerPositions = playerTransform.position,
            savedCurrentLife = mainCharacter.currentLife,
            savedCurrentPoints = mainCharacter.currentPoints,
        };
        string jsonData = JsonUtility.ToJson(savedData);
        string filePath = Application.persistentDataPath + "/SavedData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, jsonData); //Génération du fichier
    }
    private void LoadData()
    {
        string filePath = Application.persistentDataPath + "/SavedData.json";
        string jsonData = System.IO.File.ReadAllText(filePath);

        SavedData savedData = JsonUtility.FromJson<SavedData>(jsonData);

        //Chargement des données
        playerTransform.position = savedData.playerPositions;
        mainCharacter.currentLife = savedData.savedCurrentLife;
        mainCharacter.currentPoints = savedData.savedCurrentPoints;
        lifeBar.SetLifepoints(savedData.savedCurrentLife);
        mainCharacter.onSetPoints.Invoke(savedData.savedCurrentPoints);
    }
}

public class SavedData
{
    public Vector3 playerPositions;
    public float savedCurrentLife;
    public float savedCurrentPoints;
}