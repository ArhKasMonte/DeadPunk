using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [Header("Vida da base")]
    [SerializeField] int vidaMaxima = 100;
    [SerializeField] int vidaAtual = 100;

    [Header("Controle da barra de vida")]
    [SerializeField] StatusBarra vidaBarra;

    public void LevarDano(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            Debug.Log("Você morreu");
        }
        vidaBarra.DefinirStatus(vidaAtual, vidaMaxima);
    }
}
