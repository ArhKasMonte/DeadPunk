using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSpawner : MonoBehaviour
{
    [Header("Qual objeto duplicado")]
    [SerializeField] GameObject inimigo;

    [Header("Objeto com o script controler")]
    [SerializeField] GameObject controler;

    [Header("Area que vai nascer")]
    [SerializeField] Vector2 spawnArea;

    [Header("Tempo")]
    [SerializeField] float tempoSpawn;
    [SerializeField] float tempoAdicional;

    [Header("Quanto inimigos na wave")]
    [SerializeField] int inimigosPorWave;  // Variável pública para o número de inimigos por wave

    private int tempo;
    private bool waveAtivada;  // Variável de controle para verificar se a wave já foi ativada

    void Update()
    {
        tempo = controler.GetComponent<Controle>().minutos;
        Debug.Log(tempo);

        if (tempo == tempoSpawn && !waveAtivada)
        {
            StartCoroutine(SpawnWave());
            waveAtivada = true;  // Marca a wave como ativada para o tempo atual
            tempoSpawn += tempoAdicional;  // Atualiza o tempo para a próxima wave
        }

        // Reseta a variável de controle quando o tempo passa do tempoSpawn anterior
        if (tempo > tempoSpawn - tempoAdicional)
        {
            waveAtivada = false;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < inimigosPorWave; i++)
        {
            inimigoSpawn();
            yield return new WaitForSeconds(0.5f);  // Intervalo entre spawn de cada inimigo
        }
    }

    void inimigoSpawn()
    {
        Vector3 posicao = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0f);

        GameObject novoInimigo = Instantiate(inimigo);
        novoInimigo.transform.position = posicao;
    }
}