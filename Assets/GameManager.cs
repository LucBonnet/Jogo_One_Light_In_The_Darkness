using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistence
{
    private static bool paused;
    private Scene scene;
    
    void Start()
    {
        paused = false;
        scene = SceneManager.GetActiveScene();
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
        if(scene.name != "Elevador") return;

        if(scene.name != data.sceneName) {
            SceneManager.LoadScene(data.sceneName);
        }
    }

    public void SaveData(ref GameData data) {
        data.sceneName = scene.name;
    }

}
