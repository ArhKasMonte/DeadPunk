using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarra : MonoBehaviour
{
    [SerializeField] Transform barra;

    public void DefinirStatus(int atual, int maximo)
    {
        float estado = (float)atual;
        estado /= maximo;
        if (estado < 0f)
        {
            estado = 0f;
        }
        barra.transform.localScale = new Vector3(estado, 1f, 1f);
    }
}
