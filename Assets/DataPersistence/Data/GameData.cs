using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Vector3 playerPosistion;
    public string sceneName;
    public float stamina;
    public float maxStamina;
    public int playerHasCamera;
    public SerializableDictionary<string, bool> energeticosColetados;

    public GameData() {
        playerPosistion = Vector3.zero;
        sceneName = "Entrada";
        stamina = 0f;
        maxStamina = 0f;
        playerHasCamera = 0;
        energeticosColetados = new SerializableDictionary<string, bool>();
    } 
}
