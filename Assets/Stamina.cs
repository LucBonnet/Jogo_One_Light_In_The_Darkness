using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina =2000;
    public float maxStamina = 2000;
    public Image uiBar;
  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uiBar.fillAmount = stamina / maxStamina;
    }
}
