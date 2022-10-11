using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoplataforma : MonoBehaviour
{
    public static inimigoplataforma instance;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float tempo;
    [SerializeField]
    private int vidaMaxima;
    [SerializeField]
    private int vidaAtual;

    public GameObject aria;
    [SerializeField]
    private float tempoAttack;

    [SerializeField]
    private Rigidbody2D rb;
    private Animator anin;

    private bool Flip;
    public Transform alvo;
    [SerializeField]
    private float raio;
    [SerializeField]
    private LayerMask ariavisao;

    void Start()
    {
        vidaAtual = vidaMaxima;
        instance = this;
        anin = GetComponent<Animator>();
    }

    void Update()
    {
        

        Procurar();
        if (this.alvo != null)
        {
            Moveratras();
            //anin.SetBool("atack", true);

        }
        else
        {
            Move();
            //anin.SetBool("atack", false);
        }
    }

    private void Procurar()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raio, this.ariavisao);

        if (colisor != null)
        {
            this.alvo = colisor.transform;
        }
        else
        {
            this.alvo = null;
        }
    }

    private void Moveratras()
    {
        aria.SetActive(true);
        //Tempo();
        //aria.SetActive(false);

    }

    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void Rotacionar()
    {
        if (Flip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && !col.CompareTag("Player") && !col.CompareTag("chao")
            && !col.CompareTag("inimigo"))
        {
            Flip = !Flip;
        }

        Rotacionar();

        if (col.gameObject.tag.Equals("tiroPlayer"))
        {
            Morte();
        }
    }

    private void Morte()
    {
        Destroy(gameObject, tempo);
        anin.SetBool("morte_Mumia", true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raio);
    }
}
