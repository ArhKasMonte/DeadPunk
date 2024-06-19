using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] Transform baseDestino;
    GameObject baseGameobject;
    [SerializeField] float velocidade;

    Rigidbody2D rigidbody2d;


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
        }
    }

    void Dano()
    {
        Debug.Log("Atacou a base");
    }
}
