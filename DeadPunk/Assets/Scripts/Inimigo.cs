using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [Header("Lugar de destino para o inimigo")]
    [SerializeField] Transform baseDestino;

    [Header("Velocidade do inimigo")]
    [SerializeField] float velocidade;

    [Header("Dano do inimigo")]
    [SerializeField] int dano = 0;

    Rigidbody2D rigidbody2d;
    GameObject baseGameobject;
    Base baseDano;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        baseGameobject = baseDestino.gameObject;
    }

    private void FixedUpdate()
    {
        Vector3 direcao = (baseDestino.position - transform.position).normalized;
        rigidbody2d.velocity = direcao * velocidade;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == baseGameobject)
        {
            Dano();
            Destroy(this.gameObject);
        }
    }

    void Dano()
    {
        if (baseDano == null)
        {
            baseDano = baseGameobject.GetComponent<Base>();
        }

        baseDano.LevarDano(dano);
    }
}
