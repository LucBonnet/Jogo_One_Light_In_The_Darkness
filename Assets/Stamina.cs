using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour, IDataPersistence
{
    public float stamina = 100;
    public float maxStamina = 100;
    public Image uiBar;
    public PlayerControl player; // Referência ao script do jogador

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(stamina >= maxStamina){
            uiBar.enabled = false;
            stamina = maxStamina;
            player.cancado = false;
        }
        else if(stamina <= 0){
            uiBar.enabled = true;
            stamina = 0;
            player.cancado = true;
        }
        else{
           uiBar.enabled = true; 
        }
       
        uiBar.fillAmount = stamina / maxStamina;
    }

    public void LoadData(GameData data) {
        stamina = data.stamina;
        maxStamina = data.maxStamina;
    }

    public void SaveData(ref GameData data) {
        data.stamina = stamina;
        data.maxStamina = maxStamina;
    }
}
