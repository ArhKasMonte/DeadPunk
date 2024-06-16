using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Controle : MonoBehaviour
{
    // Referência ao objeto que será ativado
    [SerializeField] GameObject upgradeButton;
    [SerializeField] TextMeshProUGUI timerText;
    float tempoDecorrido;

    void Update()
    {
        //Pegando o tempo e transformando ele em segundos e minutos
        tempoDecorrido += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tempoDecorrido / 60);
        int segundos = Mathf.FloorToInt(tempoDecorrido % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void AbrirHud()
    {
        // Ativa o objeto
        if (upgradeButton != null)
        {
            upgradeButton.SetActive(true);
        }
    }

    public void FecharHud()
    {
        // Desativar o objeto
        if (upgradeButton != null)
        {
            upgradeButton.SetActive(false);
        }
    }
}
