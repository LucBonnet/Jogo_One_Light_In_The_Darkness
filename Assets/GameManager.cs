using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistence
{
    private static bool paused;
    
    void Start()
    {
        paused = false;
    }

    public static void ChangePause(bool p) {
        Time.timeScale = p ? 0 : 1;
        paused = p;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadData(GameData data) {
        // SceneManager.LoadScene(data.sceneName);
    }

    public void SaveData(ref GameData data) {
        // Scene scene = SceneManager.GetActiveScene();
        // data.sceneName = scene.name;
    }

}
