using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSpawner : MonoBehaviour
{
    [SerializeField] GameObject inimigo;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float tempoSpawn;
    private float tempo;
    private Controle controleScript;

    private void Start()
    {
        tempo = controleScript.tempoDecorrido;
    }

    void Update()
    {
        if (tempo < 0f)
        {
            inimigoSpawn();
            tempo = tempoSpawn;
        }
    }

    void inimigoSpawn()
    {
        Vector3 posicao = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0f);

        GameObject novoInimigo = Instantiate(inimigo);
        novoInimigo.transform.position = posicao;
    }
}
