using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance {get; private set;}

    private void Awake() {
        if(instance != null) {
            Debug.Log("Found more than one Data Persistence Manager in the scene");
        }
        instance = this;
    }

    private void Start() {
        // dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataHandler = new FileDataHandler("E:\\", fileName);
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame() {
        gameData = new GameData();
    }

     public void LoadGame() {
        gameData = dataHandler.Load();

        if(gameData == null) {
            NewGame();
            return;
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects) {
            dataPersistenceObj.LoadData(gameData);
        }
     }

     public void SaveGame() {
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects) {
            dataPersistenceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
     }

    private void OnApplicationQuit() {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects() {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }
}
